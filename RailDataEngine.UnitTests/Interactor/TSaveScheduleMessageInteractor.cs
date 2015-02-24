using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Core.Interactor.Schedule;
using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Domain.Interactor.SaveScheduleMessageInteractor;
using RailDataEngine.Domain.Services.ScheduleMessageConversionService;
using RailDataEngine.Domain.Services.ScheduleMessageDeserializationService;
using RailDataEngine.Domain.Services.ScheduleMessageDeserializationService.Entity;
using RailDataEngine.Domain.Services.ScheduleMessageStorageService;

namespace RailDataEngine.UnitTests.Interactor
{
    [TestFixture]
    class TSaveScheduleMessageInteractor
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var deserializationService = new Mock<IScheduleMessageDeserializationService>();
            var conversionService = new Mock<IScheduleMessageConversionService>();
            var scheduleStorageService = new Mock<IScheduleMessageStorageService>();

            Assert.Throws<ArgumentNullException>(() => new SaveScheduleMessageInteractor(null, conversionService.Object, scheduleStorageService.Object));
            Assert.Throws<ArgumentNullException>(() => new SaveScheduleMessageInteractor(deserializationService.Object, null, scheduleStorageService.Object));
            Assert.Throws<ArgumentNullException>(() => new SaveScheduleMessageInteractor(deserializationService.Object, conversionService.Object, null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var interactor = container.Resolve<ISaveScheduleMessagesInteractor>();
            Assert.IsInstanceOf<SaveScheduleMessageInteractor>(interactor);
        }

        [TestFixture]
        class SaveScheduleMessages
        {
            [Test]
            public void throws_when_request_is_null()
            {
                var deserializationService = new Mock<IScheduleMessageDeserializationService>();
                var conversionService = new Mock<IScheduleMessageConversionService>();
                var scheduleStorageService = new Mock<IScheduleMessageStorageService>();

                var interactor = new SaveScheduleMessageInteractor(deserializationService.Object,
                    conversionService.Object, scheduleStorageService.Object);

                Assert.Throws<ArgumentNullException>(() => interactor.SaveScheduleMessages(null));
                Assert.Throws<ArgumentNullException>(
                    () => interactor.SaveScheduleMessages(new SaveScheduleMessageInteractorRequest()));
            }

            [Test]
            public void calls_messages_services()
            {
                var deserializationService = new Mock<IScheduleMessageDeserializationService>();
                var conversionService = new Mock<IScheduleMessageConversionService>();
                var scheduleStorageService = new Mock<IScheduleMessageStorageService>();

                deserializationService.Setup(
                    m => m.DeserializeScheduleMessages(It.IsAny<ScheduleMessageDeserializationRequest>()))
                    .Returns(new ScheduleMessageDeserializationResponse
                    {
                        Associations = new List<DeserializedJsonAssociation>(),
                        Headers = new List<DeserializedJsonScheduleHeader>(),
                        Records = new List<DeserializedJsonScheduleRecord>(),
                        Tiplocs = new List<DeserializedJsonTiploc>()
                    });

                conversionService.Setup(m => m.ConvertScheduleMessages(It.IsAny<ScheduleMessageConversionRequest>()))
                    .Returns(new ScheduleMessageConversionResponse
                    {
                        Associations = new List<Association>(),
                        Headers = new List<Header>(),
                        Records = new List<Record>(),
                        Tiplocs = new List<Tiploc>()
                    });

                var interactor = new SaveScheduleMessageInteractor(deserializationService.Object,
                    conversionService.Object, scheduleStorageService.Object);

                interactor.SaveScheduleMessages(new SaveScheduleMessageInteractorRequest
                {
                    MessagesToSave = new List<string>
                    {
                        "lalalalalalala"   
                    }
                });
            }
        }
    }
}
