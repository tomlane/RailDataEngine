using System.Configuration;
using Microsoft.AspNet.Identity.EntityFramework;
using RailDataEngine.Services.Authentication.Entity;

namespace RailDataEngine.Services.Authentication.Data
{
    public class AuthenticationContext : IdentityDbContext<RailDataEngineUser>
    {
        public AuthenticationContext()
            :base(ConfigurationManager.ConnectionStrings["AuthenticationContext"].ConnectionString, throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static AuthenticationContext Create()
        {
            return new AuthenticationContext();
        }
    }
}
