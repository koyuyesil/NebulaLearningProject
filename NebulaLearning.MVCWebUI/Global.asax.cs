using NebulaLearning.Business.Net4x.DependencyResolvers.Ninject;
using NebulaLearning.MVCWebUI.Utilities.Mvc.InfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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