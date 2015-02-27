using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using RailDataEngine.Api.Models;
using RailDataEngine.Services.Authentication.Domain;
using RailDataEngine.Services.Authentication.Entity;

namespace RailDataEngine.Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAuthenticationGateway _authenticationGateway;

        public AccountController(IAuthenticationGateway authenticationGateway)
        {
            if (authenticationGateway == null)
                throw new ArgumentNullException("authenticationGateway");

            _authenticationGateway = authenticationGateway;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Register(UserViewModel model)
        {
            var result = await _authenticationGateway.RegisterUser(new User
            {
                UserName = model.UserName,
                Password = model.Password
            });

            if (!result.Succeeded)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return new OkResult(Request);
        }
    }
}
