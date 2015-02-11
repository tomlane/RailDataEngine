using Microsoft.Practices.Unity;
using NUnit.Framework;
using RailDataEngine.DI;
using RailDataEngine.Domain.Providers;
using RailDataEngine.Services.MessageConversion.Providers;

namespace RailDataEngine.UnitTests.Services.MessageConversion
{
    [TestFixture]
    class TMovementInformationProvider
    {
        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var provider = container.Resolve<IMovementInformationProvider>();
            Assert.IsInstanceOf<MovementInformationProvider>(provider);
        }
    }
}
