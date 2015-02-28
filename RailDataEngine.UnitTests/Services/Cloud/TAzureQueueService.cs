using Microsoft.Practices.Unity;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Services.CloudQueueService;
using RailDataEngine.Services.Cloud;

namespace RailDataEngine.UnitTests.Services.Cloud
{
    [TestFixture]
    class TAzureQueueService
    {
        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var service = container.Resolve<ICloudQueueService>();
            Assert.IsInstanceOf<AzureQueueService>(service);
        }
    }
}
