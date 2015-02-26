using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Api.Controllers;
using RailDataEngine.Core;
using RailDataEngine.Services.Authentication.Domain;

namespace RailDataEngine.UnitTests.Api.Controllers
{
    [TestFixture]
    class TAccountController
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var authenticationGateway = new Mock<IAuthenticationGateway>();

            Assert.Throws<ArgumentNullException>(() => new AccountController(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var controller = container.Resolve<AccountController>();
            Assert.IsInstanceOf<AccountController>(controller);
        }
    }
}
