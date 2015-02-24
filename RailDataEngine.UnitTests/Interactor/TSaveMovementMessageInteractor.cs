using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Core.Interactor.TrainMovements;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Interactor.SaveMovementMessageInteractor;
using RailDataEngine.Domain.Services.MovementMessageConversionService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService.Entity;
using RailDataEngine.Domain.Services.MovementMessageStorageService;

namespace RailDataEngine.UnitTests.Interactor
{
    [TestFixture]
    class TSaveMovementMessageInteractor
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var deserializationMock = new Mock<IMovementMessageDeserializationService>();
            var conversionMock = new Mock<IMovementMessageConversionService>();
            var storageMock = new Mock<IMovementMessageStorageService>();

            Assert.Throws<ArgumentNullException>(() => new SaveMovementMessageInteractor(null, conversionMock.Object, storageMock.Object));
            Assert.Throws<ArgumentNullException>(() => new SaveMovementMessageInteractor(deserializationMock.Object, null, storageMock.Object));
            Assert.Throws<ArgumentNullException>(() => new SaveMovementMessageInteractor(deserializationMock.Object, conversionMock.Object, null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var interactor = container.Resolve<ISaveMovementMessageInteractor>();
            Assert.IsInstanceOf<SaveMovementMessageInteractor>(interactor);
        }

        [TestFixture]
        class SaveMovementMessages
        {
            [Test]
            public void throws_when_request_is_null()
            {
                var deserializationMock = new Mock<IMovementMessageDeserializationService>();
                var conversionMock = new Mock<IMovementMessageConversionService>();
                var storageMock = new Mock<IMovementMessageStorageService>();

                var interactor = new SaveMovementMessageInteractor(deserializationMock.Object, conversionMock.Object, storageMock.Object);

                Assert.Throws<ArgumentNullException>(() => interactor.SaveMovementMessages(null));
                Assert.Throws<ArgumentNullException>(() => interactor.SaveMovementMessages(new SaveMovementMessageInteractorRequest()));
            }

            [Test]
            public void calls_message_services()
            {
                var deserializationMock = new Mock<IMovementMessageDeserializationService>();
                var conversionMock = new Mock<IMovementMessageConversionService>();
                var storageMock = new Mock<IMovementMessageStorageService>();

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

                var interactor = new SaveMovementMessageInteractor(deserializationMock.Object, conversionMock.Object, storageMock.Object);

                interactor.SaveMovementMessages(new SaveMovementMessageInteractorRequest
                {
                    MessageToSave = "lalala"
                });

                deserializationMock.Verify(m => m.DeserializeMovementMessages(It.IsAny<MovementMessageDeserializationRequest>()), Times.Once);
                conversionMock.Verify(m => m.ConvertMovementMessages(It.IsAny<MovementMessageConversionRequest>()), Times.Once);
                storageMock.Verify(m => m.SaveMovementMessages(It.IsAny<SaveMovementMessagesRequest>()), Times.Once);
            }
        }
    }
}
