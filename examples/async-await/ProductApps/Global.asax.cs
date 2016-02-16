using System.Web;
using System.Web.Http;

namespace ProductApps
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //var container = new WindsorContainer();
            //container.Register(
            //     Component
            //     .For<ProductApps.App_Start.configurations.IDbConnection>()
            //     .ImplementedBy<ProductApps.App_Start.configurations.DBConnection>()
            //     //.Interceptors(InterceptorReference.ForType<ExceptionAspect>()).First
            // );
            // register aspects
            //container.Register(
            //    Component.For<ExceptionAspect>()                
            //     .Parameters(Parameter.ForKey("EatAll").Eq("true"))
            //);
        }
    }
}
