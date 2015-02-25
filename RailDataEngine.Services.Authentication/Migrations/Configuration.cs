using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RailDataEngine.Services.Authentication.Data;
using RailDataEngine.Services.Authentication.Entity;

namespace RailDataEngine.Services.Authentication.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthenticationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuthenticationContext context)
        {
            var manager = new UserManager<RailDataEngineUser>(new UserStore<RailDataEngineUser>(new AuthenticationContext()));

            var user = new RailDataEngineUser
            {
                UserName = "Default",
                Email = "Default@mymail.com",
                EmailConfirmed = true
            };

            manager.Create(user, "Password12!");
        }
    }
}
