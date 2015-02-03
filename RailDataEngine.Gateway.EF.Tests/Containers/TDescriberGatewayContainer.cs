using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.DI;
using RailDataEngine.Domain.Gateway;
using RailDataEngine.Domain.Gateway.Entity.TrainDescriber.Berth;
using RailDataEngine.Domain.Gateway.Entity.TrainDescriber.Signal;
using RailDataEngine.Gateway.EF.Containers;

namespace RailDataEngine.Gateway.EF.Tests.Containers
{
    [TestFixture]
    class TDescriberGatewayContainer
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var berthGateway = new Mock<IStorageGateway<BerthMessageEntity>>();
            var signalGateway = new Mock<IStorageGateway<SignalMessageEntity>>();

            Assert.Throws<ArgumentNullException>(() => new TrainDescriberGatewayContainer(null, signalGateway.Object));
            Assert.Throws<ArgumentNullException>(() => new TrainDescriberGatewayContainer(berthGateway.Object, null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var gatewayContainer = container.Resolve<ITrainDescriberContainer>();
            Assert.IsInstanceOf<TrainDescriberGatewayContainer>(gatewayContainer);
        }
    }
}
