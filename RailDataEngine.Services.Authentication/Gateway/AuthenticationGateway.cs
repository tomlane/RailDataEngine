using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RailDataEngine.Services.Authentication.Data;
using RailDataEngine.Services.Authentication.Domain;
using RailDataEngine.Services.Authentication.Entity;

namespace RailDataEngine.Services.Authentication.Gateway
{
    public class AuthenticationGateway : IAuthenticationGateway
    {
        private RailDataEngineUserManager _userManager;
        private AuthenticationContext _context;

        public AuthenticationGateway()
        {
            _context = AuthenticationContext.Create();
            _userManager = new RailDataEngineUserManager(new UserStore<RailDataEngineUser>(_context));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            RailDataEngineUser user = new RailDataEngineUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            RailDataEngineUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _context.Dispose();
            _userManager.Dispose();
        }
    }
}
