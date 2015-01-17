using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Data.Schedule;
using RailDataEngine.Gateway.Domain;
using RailDataEngine.Gateway.EF.Schedule;
using RailDataEngine.Gateway.Entity.Schedule;
using RailDataEngine.Root;

namespace RailDataEngine.Gateway.EF.Tests.Schedule
{
    [TestFixture]
    class TRecordGateway
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var database = new Mock<IScheduleDatabase>();

            Assert.Throws<ArgumentNullException>(() => new RecordGateway(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var gateway = container.Resolve<IStorageGateway<RecordEntity>>();
            Assert.IsInstanceOf<RecordGateway>(gateway);
        }
    }
}
