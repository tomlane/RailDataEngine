using Microsoft.Practices.Unity;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Services.ScheduleMessageDeserializationService;
using RailDataEngine.Services.MessageConversion.Schedule;

namespace RailDataEngine.UnitTests.Services.MessageConversion.Schedule
{
    [TestFixture]
    class TJsonScheduleMessageDeserializationService
    {
        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var service = container.Resolve<IScheduleMessageDeserializationService>();
            Assert.IsInstanceOf<JsonScheduleMessageDeserializationService>(service);
        }
    }
}
