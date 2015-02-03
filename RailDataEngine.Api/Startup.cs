using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Exceptionless;
using Microsoft.Owin;
using Microsoft.Practices.Unity.WebApi;
using Owin;

[assembly: OwinStartup(typeof(RailDataEngine.Api.Startup))]

namespace RailDataEngine.Api
{
    public class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; set; }

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration = new HttpConfiguration
            {
                DependencyResolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer())
            };

            ExceptionlessClient.Current.RegisterWebApi(HttpConfiguration);
            WebApiConfig.Register(HttpConfiguration);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            app.UseWebApi(HttpConfiguration);
        }
    }
}
