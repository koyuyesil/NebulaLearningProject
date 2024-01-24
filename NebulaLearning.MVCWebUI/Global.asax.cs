using NebulaLearning.Business.Net4x.DependencyResolvers.Ninject;
using NebulaLearning.Core.Net4x.CrossCuttingConserns.Security.Web;
using NebulaLearning.MVCWebUI.Utilities.Mvc.InfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace NebulaLearning.MVCWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinectControllerFactory(new BusinessModule()));
        }
        // cerez eventinin ayarlanmasý
        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {//kiþinin yetkilendirme bilgilerine eriþebilir olduðu zaman;
            try
            {
                // default auth cookie varmý baklýr. ".ASPXAUTH"
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return;
                }
                var encTicket = authCookie.Value;
                if (String.IsNullOrEmpty(encTicket)) { return; }
                var ticket = FormsAuthentication.Decrypt(encTicket);
                var securityUtilities = new SecurityUtilities();
                var identity = securityUtilities.FormsAuthTicketToIdentity(ticket);
                var principal = new GenericPrincipal(identity, identity.Roles);
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch (Exception)
            {
            }
        }
    }
}
//Bu kod, ASP.NET MVC uygulamanýzýn baþlangýcýnda çaðrýlan Application_Start metodunu içeriyor.
//Bu metod, uygulamanýzýn baþlatýlmasý sýrasýnda gerçekleþen konfigürasyonlarý ve kayýtlarý içerir.
//Bu özel kod parçasý þu görevleri gerçekleþtirir:
//AreaRegistration.RegisterAllAreas();: MVC alanlarýný kaydederek, projenizde belirli alanlara ait controller'larý tanýmlar.
//RouteConfig.RegisterRoutes(RouteTable.Routes);: MVC rota konfigürasyonunu yapar. Yani, URL'leri belirli controller ve action'lara yönlendirir.
//ControllerBuilder.Current.SetControllerFactory(new NinectControllerFactory(new BusinessModule()));: Bu satýr, belirli bir ControllerFactory'nin (NinjectControllerFactory) kullanýlmasýný saðlar.
//NinjectControllerFactory, dependency injection (baðýmlýlýk enjeksiyonu) kullanarak controller'larý oluþturur. BusinessModule ise bu enjeksiyonun ne tür baðýmlýlýklarý içereceðini tanýmlar.
//Bu kod, özellikle dependency injection kullanýmý sayesinde uygulamanýzýn geniþletilebilirliðini artýrabilir ve baðýmlýlýklar arasýndaki sýký baðlarý azaltabilir.