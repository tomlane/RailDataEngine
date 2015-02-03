using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.DI;
using RailDataEngine.Domain.Gateway;
using RailDataEngine.Domain.Gateway.Entity.Schedule;
using RailDataEngine.Gateway.EF.Containers;

namespace RailDataEngine.Gateway.EF.Tests.Containers
{
    [TestFixture]
    class TScheduleGatewayContainer
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var associationGateway = new Mock<IStorageGateway<AssociationEntity>>();
            var headerGateway = new Mock<IStorageGateway<HeaderEntity>>();
            var locationGateway = new Mock<IStorageGateway<LocationEntity>>();
            var recordGateway = new Mock<IStorageGateway<RecordEntity>>();
            var tiplocGateway = new Mock<IStorageGateway<TiplocEntity>>();

            Assert.Throws<ArgumentNullException>(() => new ScheduleGatewayContainer(null, headerGateway.Object, locationGateway.Object, recordGateway.Object, tiplocGateway.Object));
            Assert.Throws<ArgumentNullException>(() => new ScheduleGatewayContainer(associationGateway.Object, null, locationGateway.Object, recordGateway.Object, tiplocGateway.Object));
            Assert.Throws<ArgumentNullException>(() => new ScheduleGatewayContainer(associationGateway.Object, headerGateway.Object, null, recordGateway.Object, tiplocGateway.Object));
            Assert.Throws<ArgumentNullException>(() => new ScheduleGatewayContainer(associationGateway.Object, headerGateway.Object, locationGateway.Object, null, tiplocGateway.Object));
            Assert.Throws<ArgumentNullException>(() => new ScheduleGatewayContainer(associationGateway.Object, headerGateway.Object, locationGateway.Object, recordGateway.Object, null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var gatewayContainer = container.Resolve<IScheduleGatewayContainer>();
            Assert.IsInstanceOf<ScheduleGatewayContainer>(gatewayContainer);
        }
    }
}
