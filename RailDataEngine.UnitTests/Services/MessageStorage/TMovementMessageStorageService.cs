using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Gateway.TrainMovements;
using RailDataEngine.Domain.Services.MovementMessageStorageService;
using RailDataEngine.Services.MessageStorage;
using RailDataEngine.UnitTests.Common;

namespace RailDataEngine.UnitTests.Services.MessageStorage
{
    [TestFixture]
    class TMovementMessageStorageService
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var gatewayContainer = new Mock<ITrainMovementGatewayContainer>();

            Assert.Throws<ArgumentNullException>(() => new MovementMessageStorageService(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var service = container.Resolve<IMovementMessageStorageService>();
            Assert.IsInstanceOf<MovementMessageStorageService>(service);
        }

        [TestFixture]
        class SaveMovementMessages
        {
            [Test]
            public void throws_when_request_is_null()
            {
                var gatewayContainer = MockHelpers.BuildMovementGatewayContainer();

                var service = new MovementMessageStorageService(gatewayContainer.Object);

                Assert.Throws<ArgumentNullException>(() => service.SaveMovementMessages(null));
            }

            [Test]
            public void does_not_call_gateways_with_no_messages_to_save()
            {
                var gatewayContainer = MockHelpers.BuildMovementGatewayContainer();

                var service = new MovementMessageStorageService(gatewayContainer.Object);

                service.SaveMovementMessages(new SaveMovementMessagesRequest());

                gatewayContainer.Verify(m => m.ActivationGateway, Times.Never);
                gatewayContainer.Verify(m => m.CancellationGateway, Times.Never);
                gatewayContainer.Verify(m => m.MovementGateway, Times.Never);

                service.SaveMovementMessages(new SaveMovementMessagesRequest
                {
                    Activations = new List<TrainActivation>(),
                    Cancellations = new List<TrainCancellation>(),
                    Movements = new List<TrainMovement>()
                });

                gatewayContainer.Verify(m => m.ActivationGateway, Times.Never);
                gatewayContainer.Verify(m => m.CancellationGateway, Times.Never);
                gatewayContainer.Verify(m => m.MovementGateway, Times.Never);
            }

            [Test]
            public void calls_gateways_correct_amount_of_times()
            {
                var gatewayContainer = MockHelpers.BuildMovementGatewayContainer();

                var service = new MovementMessageStorageService(gatewayContainer.Object);

                service.SaveMovementMessages(new SaveMovementMessagesRequest
                {
                    Activations = new List<TrainActivation>
                    {
                        new TrainActivation(),
                        new TrainActivation()
                    },
                    Cancellations = new List<TrainCancellation>
                    {
                        new TrainCancellation()
                    },
                    Movements = new List<TrainMovement>
                    {
                        new TrainMovement(),
                        new TrainMovement(),
                        new TrainMovement()
                    }
                });

                gatewayContainer.Verify(m => m.ActivationGateway, Times.Once);
                gatewayContainer.Verify(m => m.CancellationGateway, Times.Once);
                gatewayContainer.Verify(m => m.MovementGateway, Times.Once);
            }
        }
    }
}
