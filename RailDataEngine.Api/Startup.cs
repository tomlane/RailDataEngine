using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Exceptionless;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity.WebApi;
using Owin;
using RailDataEngine.Services.Authentication;
using RailDataEngine.Services.Authentication.Data;

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

            ConfigureOAuth(app);
            WebApiConfig.Register(HttpConfiguration);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(HttpConfiguration);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(AuthenticationContext.Create);
            app.CreatePerOwinContext<RailDataEngineUserManager>(RailDataEngineUserManager.Create);

            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
