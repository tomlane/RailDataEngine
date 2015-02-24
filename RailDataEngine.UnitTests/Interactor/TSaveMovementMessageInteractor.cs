﻿using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Core.Interactor.TrainMovements;
using RailDataEngine.Domain.Gateway.TrainMovements;
using RailDataEngine.Domain.Interactor.SaveMovementMessageInteractor;
using RailDataEngine.Domain.Services.MovementMessageConversionService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService;

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
            var gatewayContainerMock = new Mock<ITrainMovementGatewayContainer>();

            Assert.Throws<ArgumentNullException>(() => new SaveMovementMessageInteractor(null, conversionMock.Object, gatewayContainerMock.Object));
            Assert.Throws<ArgumentNullException>(() => new SaveMovementMessageInteractor(deserializationMock.Object, null, gatewayContainerMock.Object));
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
                var gatewayContainerMock = new Mock<ITrainMovementGatewayContainer>();

                var interactor = new SaveMovementMessageInteractor(deserializationMock.Object, conversionMock.Object, gatewayContainerMock.Object);

                Assert.Throws<ArgumentNullException>(() => interactor.SaveMovementMessages(null));
                Assert.Throws<ArgumentNullException>(() => interactor.SaveMovementMessages(new SaveMovementMessageInteractorRequest
                {
                    MessageToSave = null
                }));
            }
        }
    }
}
