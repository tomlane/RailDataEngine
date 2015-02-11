using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.DI;
using RailDataEngine.Domain.Providers;
using RailDataEngine.Domain.Services.MessageValidationService;
using RailDataEngine.Domain.Services.ScheduleMessageConversionService;
using RailDataEngine.Domain.Services.TimeConversionService;
using RailDataEngine.Services.MessageConversion.Schedule;

namespace RailDataEngine.UnitTests.Services.MessageConversion.Schedule
{
    [TestFixture]
    class TJsonScheduleMessageConversionService
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var messageValidationMock = new Mock<IMessageValidationService>();
            var timeConversionMock = new Mock<ITimeConversionService>();
            var trainProviderMock = new Mock<ITrainInformationProvider>();
            var scheduleProviderMock = new Mock<IScheduleInformationProvider>();

            Assert.Throws<ArgumentNullException>(() => new JsonScheduleMessageConversionService(null, scheduleProviderMock.Object, timeConversionMock.Object, trainProviderMock.Object));
            Assert.Throws<ArgumentNullException>(() => new JsonScheduleMessageConversionService(messageValidationMock.Object, null, timeConversionMock.Object, trainProviderMock.Object));
            Assert.Throws<ArgumentNullException>(() => new JsonScheduleMessageConversionService(messageValidationMock.Object, scheduleProviderMock.Object, null, trainProviderMock.Object));
            Assert.Throws<ArgumentNullException>(() => new JsonScheduleMessageConversionService(messageValidationMock.Object, scheduleProviderMock.Object, timeConversionMock.Object, null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var serivce = container.Resolve<IScheduleMessageConversionService>();
            Assert.IsInstanceOf<JsonScheduleMessageConversionService>(serivce);
        }
    }
}
