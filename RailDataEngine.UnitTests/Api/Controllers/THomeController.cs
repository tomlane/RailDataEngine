using System.Web.Mvc;
using NUnit.Framework;
using RailDataEngine.Api.Controllers;

namespace RailDataEngine.UnitTests.Api.Controllers
{
    [TestFixture]
    class THomeController
    {
        [Test]
        public void redirects_to_help_page()
        {
            var controller = new HomeController();
            var result = (RedirectToRouteResult)controller.Index();

            Assert.AreEqual("Help", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
