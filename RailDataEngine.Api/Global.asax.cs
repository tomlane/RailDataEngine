using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Exceptionless;

namespace RailDataEngine.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ExceptionlessClient.Current.RegisterWebApi(GlobalConfiguration.Configuration);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
