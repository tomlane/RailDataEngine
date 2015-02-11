using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.DI;
using RailDataEngine.Domain.Providers;
using RailDataEngine.Domain.Services.MessageValidationService;
using RailDataEngine.Domain.Services.MovementMessageConversionService;
using RailDataEngine.Domain.Services.TimeConversionService;
using RailDataEngine.Services.MessageConversion.TrainMovements;

namespace RailDataEngine.UnitTests.Services.MessageConversion.TrainMovements
{
    [TestFixture]
    class TJsonMovementMessageConversionService
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var messageValidationMock = new Mock<IMessageValidationService>();
            var timeConversionMock = new Mock<ITimeConversionService>();
            var movementProviderMock = new Mock<IMovementInformationProvider>();
            var scheduleProviderMock = new Mock<IScheduleInformationProvider>();

            Assert.Throws<ArgumentNullException>(() => new JsonMovementMessageConversionService(null, timeConversionMock.Object, movementProviderMock.Object, scheduleProviderMock.Object));
            Assert.Throws<ArgumentNullException>(() => new JsonMovementMessageConversionService(messageValidationMock.Object, null, movementProviderMock.Object, scheduleProviderMock.Object));
            Assert.Throws<ArgumentNullException>(() => new JsonMovementMessageConversionService(messageValidationMock.Object, timeConversionMock.Object, null, scheduleProviderMock.Object));
            Assert.Throws<ArgumentNullException>(() => new JsonMovementMessageConversionService(messageValidationMock.Object, timeConversionMock.Object, movementProviderMock.Object, null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var service = container.Resolve<IMovementMessageConversionService>();
            Assert.IsInstanceOf<JsonMovementMessageConversionService>(service);
        }
    }
}
