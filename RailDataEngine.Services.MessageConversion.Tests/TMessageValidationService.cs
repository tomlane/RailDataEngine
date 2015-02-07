using Microsoft.Practices.Unity;
using NUnit.Framework;
using RailDataEngine.DI;
using RailDataEngine.Domain.Services.MessageValidationService;

namespace RailDataEngine.Services.MessageConversion.Tests
{
    [TestFixture]
    class TMessageValidationService
    {
        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var service = container.Resolve<IMessageValidationService>();
            Assert.IsInstanceOf<MessageValidationService>(service);
        }
    }
}
