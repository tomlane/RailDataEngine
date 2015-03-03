using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(SignalRRole.Startup))]

namespace SignalRRole
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
#if DEBUG
            app.UseErrorPage();
#endif
            app.UseWelcomePage("/");
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}
