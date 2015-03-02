using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Core.Interactor.TrainMovements;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Interactor.ProcessMovementMessageInteractor;
using RailDataEngine.Domain.Services.CloudQueueService;
using RailDataEngine.Domain.Services.MovementMessageConversionService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService.Entity;
using RailDataEngine.Domain.Services.MovementMessageStorageService;
using RailDataEngine.Domain.Services.TwitterService;

namespace RailDataEngine.UnitTests.Interactor
{
    [TestFixture]
    class TProcessMovementMessageInteractor
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var deserializationMock = new Mock<IMovementMessageDeserializationService>();
            var conversionMock = new Mock<IMovementMessageConversionService>();
            var cloudMock = new Mock<ICloudQueueService>();

            Assert.Throws<ArgumentNullException>(() => new ProcessMovementMessageInteractor(null, conversionMock.Object, cloudMock.Object));
            Assert.Throws<ArgumentNullException>(() => new ProcessMovementMessageInteractor(deserializationMock.Object, null, cloudMock.Object));
            Assert.Throws<ArgumentNullException>(() => new ProcessMovementMessageInteractor(deserializationMock.Object, conversionMock.Object, null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var interactor = container.Resolve<IProcessMovementMessageInteractor>();
            Assert.IsInstanceOf<ProcessMovementMessageInteractor>(interactor);
        }

        [TestFixture]
        class SaveMovementMessages
        {
            [Test]
            public void throws_when_request_is_null()
            {
                var deserializationMock = new Mock<IMovementMessageDeserializationService>();
                var conversionMock = new Mock<IMovementMessageConversionService>();
                var cloudMock = new Mock<ICloudQueueService>();

                var interactor = new ProcessMovementMessageInteractor(deserializationMock.Object, conversionMock.Object, cloudMock.Object);

                Assert.Throws<ArgumentNullException>(() => interactor.ProcessMovementMessages(null));
                Assert.Throws<ArgumentNullException>(() => interactor.ProcessMovementMessages(new ProcessMovementMessageInteractorRequest()));
            }

            [Test]
            public void calls_message_services()
            {
                var deserializationMock = new Mock<IMovementMessageDeserializationService>();
                var conversionMock = new Mock<IMovementMessageConversionService>();
                var cloudMock = new Mock<ICloudQueueService>();

                deserializationMock.Setup(
                    m => m.DeserializeMovementMessages(It.IsAny<MovementMessageDeserializationRequest>()))
                    .Returns(new MovementMessageDeserializationResponse
                    {
                        Activations = new List<DeserializedJsonTrainActivation>(),
                        Cancellations = new List<DeserializedJsonTrainCancellation>(),
                        Movements = new List<DeserializedJsonTrainMovement>()
                    });

                conversionMock.Setup(m => m.ConvertMovementMessages(It.IsAny<MovementMessageConversionRequest>()))
                    .Returns(new MovementMessageConversionResponse
                    {
                        Activations = new List<TrainActivation>(),
                        Cancellations = new List<TrainCancellation>(),
                        Movements = new List<TrainMovement>()
                    });

                var interactor = new ProcessMovementMessageInteractor(deserializationMock.Object, conversionMock.Object, cloudMock.Object);

                interactor.ProcessMovementMessages(new ProcessMovementMessageInteractorRequest
                {
                    MessageToSave = "lalala"
                });

                deserializationMock.Verify(m => m.DeserializeMovementMessages(It.IsAny<MovementMessageDeserializationRequest>()), Times.Once);
                conversionMock.Verify(m => m.ConvertMovementMessages(It.IsAny<MovementMessageConversionRequest>()), Times.Once);
                cloudMock.Verify(m => m.AddToServiceBusQueue(It.IsAny<CloudQueueServiceRequest>()), Times.Once);
            }
        }
    }
}
