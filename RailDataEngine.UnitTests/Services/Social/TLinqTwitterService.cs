using Microsoft.Practices.Unity;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Services.TwitterService;
using RailDataEngine.Services.Social;

namespace RailDataEngine.UnitTests.Services.Social
{
    [TestFixture]
    class TLinqTwitterService
    {
        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var service = container.Resolve<ITwitterService>();
            Assert.IsInstanceOf<LinqTwitterService>(service);
        }
    }
}
