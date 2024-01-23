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
//Bu kod, ASP.NET MVC uygulamanızın başlangıcında çağrılan Application_Start metodunu içeriyor.
//Bu metod, uygulamanızın başlatılması sırasında gerçekleşen konfigürasyonları ve kayıtları içerir.
//Bu özel kod parçası şu görevleri gerçekleştirir:
//AreaRegistration.RegisterAllAreas();: MVC alanlarını kaydederek, projenizde belirli alanlara ait controller'ları tanımlar.
//RouteConfig.RegisterRoutes(RouteTable.Routes);: MVC rota konfigürasyonunu yapar. Yani, URL'leri belirli controller ve action'lara yönlendirir.
//ControllerBuilder.Current.SetControllerFactory(new NinectControllerFactory(new BusinessModule()));: Bu satır, belirli bir ControllerFactory'nin (NinjectControllerFactory) kullanılmasını sağlar.
//NinjectControllerFactory, dependency injection (bağımlılık enjeksiyonu) kullanarak controller'ları oluşturur. BusinessModule ise bu enjeksiyonun ne tür bağımlılıkları içereceğini tanımlar.
//Bu kod, özellikle dependency injection kullanımı sayesinde uygulamanızın genişletilebilirliğini artırabilir ve bağımlılıklar arasındaki sıkı bağları azaltabilir.