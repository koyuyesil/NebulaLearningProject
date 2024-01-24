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
        // cerez eventinin ayarlanmas�
        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {//ki�inin yetkilendirme bilgilerine eri�ebilir oldu�u zaman;
            try
            {
                // default auth cookie varm� bakl�r. ".ASPXAUTH"
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
//Bu kod, ASP.NET MVC uygulaman�z�n ba�lang�c�nda �a�r�lan Application_Start metodunu i�eriyor.
//Bu metod, uygulaman�z�n ba�lat�lmas� s�ras�nda ger�ekle�en konfig�rasyonlar� ve kay�tlar� i�erir.
//Bu �zel kod par�as� �u g�revleri ger�ekle�tirir:
//AreaRegistration.RegisterAllAreas();: MVC alanlar�n� kaydederek, projenizde belirli alanlara ait controller'lar� tan�mlar.
//RouteConfig.RegisterRoutes(RouteTable.Routes);: MVC rota konfig�rasyonunu yapar. Yani, URL'leri belirli controller ve action'lara y�nlendirir.
//ControllerBuilder.Current.SetControllerFactory(new NinectControllerFactory(new BusinessModule()));: Bu sat�r, belirli bir ControllerFactory'nin (NinjectControllerFactory) kullan�lmas�n� sa�lar.
//NinjectControllerFactory, dependency injection (ba��ml�l�k enjeksiyonu) kullanarak controller'lar� olu�turur. BusinessModule ise bu enjeksiyonun ne t�r ba��ml�l�klar� i�erece�ini tan�mlar.
//Bu kod, �zellikle dependency injection kullan�m� sayesinde uygulaman�z�n geni�letilebilirli�ini art�rabilir ve ba��ml�l�klar aras�ndaki s�k� ba�lar� azaltabilir.