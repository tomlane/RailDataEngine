using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Services.ScheduleMessageStorageService;
using RailDataEngine.Services.MessageStorage;
using RailDataEngine.UnitTests.Common;

namespace RailDataEngine.UnitTests.Services.MessageStorage
{
    [TestFixture]
    class TScheduleMessageStorageService
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var gatewayContainerMock = MockHelpers.BuildScheduleGatewayContainer();

            Assert.Throws<ArgumentNullException>(() => new ScheduleMessageStorageService(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var service = container.Resolve<IScheduleMessageStorageService>();
            Assert.IsInstanceOf<ScheduleMessageStorageService>(service);
        }

        [TestFixture]
        class SaveScheduleMessages
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var gatewayContainerMock = MockHelpers.BuildScheduleGatewayContainer();

                var service = new ScheduleMessageStorageService(gatewayContainerMock.Object);

                Assert.Throws<ArgumentNullException>(() => service.SaveScheduleMessages(null));
            }

            [Test]
            public void does_not_call_gateways_if_request_empty()
            {
                var gatewayContainerMock = MockHelpers.BuildScheduleGatewayContainer();

                var service = new ScheduleMessageStorageService(gatewayContainerMock.Object);

                service.SaveScheduleMessages(new SaveScheduleMessagesRequest());

                gatewayContainerMock.Verify(m => m.AssociationGateway, Times.Never);
                gatewayContainerMock.Verify(m => m.HeaderGateway, Times.Never);
                gatewayContainerMock.Verify(m => m.RecordGateway, Times.Never);
                gatewayContainerMock.Verify(m => m.TiplocGateway, Times.Never);
            }
        }
    }
}
