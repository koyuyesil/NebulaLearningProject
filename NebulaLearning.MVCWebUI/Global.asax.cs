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
            // BusinessModule Eneksiyonu
            ControllerBuilder.Current.SetControllerFactory(new NinectControllerFactory(new BusinessModule(), new AutoMapperModule())); // TODO : AUTOMAPPER STEP 9 :
        }
        // cerez eventinin ayarlanması
        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {//kişinin yetkilendirme bilgilerine erişebilir olduğu zaman;
            try
            {
                // default auth cookie varmı baklır. ".ASPXAUTH"
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
//Bu kod, ASP.NET MVC uygulamanızın başlangıcında çağrılan Application_Start metodunu içeriyor.
//Bu metod, uygulamanızın başlatılması sırasında gerçekleşen konfigürasyonları ve kayıtları içerir.
//Bu özel kod parçası şu görevleri gerçekleştirir:
//AreaRegistration.RegisterAllAreas();: MVC alanlarını kaydederek, projenizde belirli alanlara ait controller'ları tanımlar.
//RouteConfig.RegisterRoutes(RouteTable.Routes);: MVC rota konfigürasyonunu yapar. Yani, URL'leri belirli controller ve action'lara yönlendirir.
//ControllerBuilder.Current.SetControllerFactory(new NinectControllerFactory(new BusinessModule()));: Bu satır, belirli bir ControllerFactory'nin (NinjectControllerFactory) kullanılmasını sağlar.
//NinjectControllerFactory, dependency injection (bağımlılık enjeksiyonu) kullanarak controller'ları oluşturur. BusinessModule ise bu enjeksiyonun ne tür bağımlılıkları içereceğini tanımlar.
//Bu kod, özellikle dependency injection kullanımı sayesinde uygulamanızın genişletilebilirliğini artırabilir ve bağımlılıklar arasındaki sıkı bağları azaltabilir.