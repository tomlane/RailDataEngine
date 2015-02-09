using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.DI;
using RailDataEngine.Domain.Interactor.SaveScheduleMessageInteractor;
using RailDataEngine.Domain.Services.ScheduleMessageConversionService;
using RailDataEngine.Domain.Services.ScheduleMessageDeserializationService;
using RailDataEngine.Interactor.Implementations;

namespace RailDataEngine.Interactor.Tests
{
    [TestFixture]
    class TSaveScheduleMessageInteractor
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var deserializationService = new Mock<IScheduleMessageDeserializationService>();
            var conversionService = new Mock<IScheduleMessageConversionService>();

            Assert.Throws<ArgumentNullException>(() => new SaveScheduleMessageInteractor(null, conversionService.Object));
            Assert.Throws<ArgumentNullException>(() => new SaveScheduleMessageInteractor(deserializationService.Object, null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var interactor = container.Resolve<ISaveScheduleMessagesInteractor>();
            Assert.IsInstanceOf<SaveScheduleMessageInteractor>(interactor);
        }
    }
}
