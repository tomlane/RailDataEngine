using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using RailDataEngine.Services.Authentication.Data;
using RailDataEngine.Services.Authentication.Entity;

namespace RailDataEngine.Services.Authentication
{
    public class RailDataEngineUserManager : UserManager<RailDataEngineUser>
    {
        public RailDataEngineUserManager(IUserStore<RailDataEngineUser> store) : base(store)
        {
        }

        public static RailDataEngineUserManager Create(IdentityFactoryOptions<RailDataEngineUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<AuthenticationContext>();
            var appUserManager = new RailDataEngineUserManager(new UserStore<RailDataEngineUser>(appDbContext));

            return appUserManager;
        }
    }
}
