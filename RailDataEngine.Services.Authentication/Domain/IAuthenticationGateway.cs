using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RailDataEngine.Services.Authentication.Entity;

namespace RailDataEngine.Services.Authentication.Domain
{
    public interface IAuthenticationGateway : IDisposable
    {
        Task<IdentityResult> RegisterUser(UserModel user);
        Task<IdentityUser> FindUser(string userName, string password);
    }
}
