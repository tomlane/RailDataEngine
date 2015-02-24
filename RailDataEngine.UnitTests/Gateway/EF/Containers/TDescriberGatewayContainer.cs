using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Entity.TrainDescriber.Berth;
using RailDataEngine.Domain.Entity.TrainDescriber.Signal;
using RailDataEngine.Domain.Gateway.TrainDescriber;
using RailDataEngine.Gateway.EF.Containers;

namespace RailDataEngine.UnitTests.Gateway.EF.Containers
{
    [TestFixture]
    class TDescriberGatewayContainer
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var berthGateway = new Mock<ITrainDescriberStorageGateway<BerthMessage>>();
            var signalGateway = new Mock<ITrainDescriberStorageGateway<SignalMessage>>();

            Assert.Throws<ArgumentNullException>(() => new TrainDescriberGatewayContainer(null, signalGateway.Object));
            Assert.Throws<ArgumentNullException>(() => new TrainDescriberGatewayContainer(berthGateway.Object, null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var gatewayContainer = container.Resolve<ITrainDescriberGatewayContainer>();
            Assert.IsInstanceOf<TrainDescriberGatewayContainer>(gatewayContainer);
        }
    }
}
