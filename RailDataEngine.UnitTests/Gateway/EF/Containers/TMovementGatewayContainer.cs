using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.DI;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Gateway.TrainMovements;
using RailDataEngine.Gateway.EF.Containers;

namespace RailDataEngine.UnitTests.Gateway.EF.Containers
{
    [TestFixture]
    class TMovementGatewayContainer
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var activationGateway = new Mock<ITrainMovementStorageGateway<TrainActivation>>();
            var cancellationGateway = new Mock<ITrainMovementStorageGateway<TrainCancellation>>();
            var movementGateway = new Mock<ITrainMovementStorageGateway<TrainMovement>>();

            Assert.Throws<ArgumentNullException>(() => new TrainMovementGatewayContainer(null, cancellationGateway.Object, movementGateway.Object));
            Assert.Throws<ArgumentNullException>(() => new TrainMovementGatewayContainer(activationGateway.Object, null, movementGateway.Object));
            Assert.Throws<ArgumentNullException>(() => new TrainMovementGatewayContainer(activationGateway.Object, cancellationGateway.Object, null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var gatewayContainer = container.Resolve<ITrainMovementGatewayContainer>();
            Assert.IsInstanceOf<TrainMovementGatewayContainer>(gatewayContainer);
        }
    }
}
