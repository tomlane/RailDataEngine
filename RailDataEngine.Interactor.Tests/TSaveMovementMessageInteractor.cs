using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.DI;
using RailDataEngine.Domain.Interactor.SaveMovementMessageInteractor;
using RailDataEngine.Domain.Services.MovementMessageConversionService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService;
using RailDataEngine.Interactor.Implementations;

namespace RailDataEngine.Interactor.Tests
{
    [TestFixture]
    class TSaveMovementMessageInteractor
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var deserializationMock = new Mock<IMovementMessageDeserializationService>();
            var conversionMock = new Mock<IMovementMessageConversionService>();

            Assert.Throws<ArgumentNullException>(() => new SaveMovementMessageInteractor(null, conversionMock.Object));
            Assert.Throws<ArgumentNullException>(() => new SaveMovementMessageInteractor(deserializationMock.Object, null));
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

                var interactor = new SaveMovementMessageInteractor(deserializationMock.Object, conversionMock.Object);

                Assert.Throws<ArgumentNullException>(() => interactor.SaveMovementMessages(null));
                Assert.Throws<ArgumentNullException>(() => interactor.SaveMovementMessages(new SaveMovementMessageInteractorRequest
                {
                    MessageToSave = null
                }));
            }
        }
    }
}
