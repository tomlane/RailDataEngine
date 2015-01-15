using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Data.Schedule;
using RailDataEngine.Gateway.Domain;
using RailDataEngine.Gateway.EF.Schedule;
using RailDataEngine.Gateway.Entity.Schedule;
using RailDataEngine.Root;
using RailDataEngine.Tests.Common;

namespace RailDataEngine.Gateway.EF.Tests.Schedule
{
    [TestFixture]
    class TAssociationGateway
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var database = new Mock<IScheduleDatabase>();

            Assert.Throws<ArgumentNullException>(() => new AssociationGateway(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var gateway = container.Resolve<IStorageGateway<AssociationEntity>>();
            Assert.IsInstanceOf<AssociationGateway>(gateway);
        }

        [TestFixture]
        class Create
        {
            [Test]
            public void throws_when_argument_null()
            {
                var database = new Mock<IScheduleDatabase>();
                var context = new Mock<IScheduleContext>();

                database.Setup(m => m.BuildContext()).Returns(context.Object);

                var gateway = new AssociationGateway(database.Object);

                Assert.Throws<ArgumentNullException>(() => gateway.Create(null));
            }

            [Test]
            public void calls_context_when_passed_entity()
            {
                var database = new Mock<IScheduleDatabase>();
                var context = new Mock<IScheduleContext>();

                var mockSet = MockHelpers.BuildMockSet(new List<AssociationEntity>());

                context.Setup(m => m.GetSet<AssociationEntity>()).Returns(mockSet.Object);

                database.Setup(m => m.BuildContext()).Returns(context.Object);

                var gateway = new AssociationGateway(database.Object);

                gateway.Create(new AssociationEntity());

                context.Verify(m => m.SaveChanges(), Times.Once);
            }
        }
    }
}
