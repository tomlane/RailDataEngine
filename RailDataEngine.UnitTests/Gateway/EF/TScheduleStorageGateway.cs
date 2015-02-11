using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Data.Schedule;
using RailDataEngine.DI;
using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Domain.Gateway.Schedule;
using RailDataEngine.Gateway.EF;
using RailDataEngine.UnitTests.Common;

namespace RailDataEngine.UnitTests.Gateway.EF
{
    [TestFixture]
    class TScheduleStorageGateway
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var database = new Mock<IScheduleDatabase>();

            Assert.Throws<ArgumentNullException>(() => new ScheduleStorageGateway<Association>(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var gateway = container.Resolve<IScheduleStorageGateway<Association>>();
            Assert.IsInstanceOf<ScheduleStorageGateway<Association>>(gateway);
        }

        [TestFixture]
        class Create
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var database = new Mock<IScheduleDatabase>();
                var gateway = new ScheduleStorageGateway<Association>(database.Object);

                Assert.Throws<ArgumentNullException>(() => gateway.Create(null));
            }

            [Test]
            public void calls_save_changes_on_context()
            {
                var database = new Mock<IScheduleDatabase>();
                var context = new Mock<IScheduleContext>();

                var entitySet = new List<Association>();

                context.Setup(m => m.GetSet<Association>()).Returns(MockHelpers.BuildMockSet(entitySet).Object);

                database.Setup(m => m.BuildContext()).Returns(context.Object);

                var gateway = new ScheduleStorageGateway<Association>(database.Object);

                gateway.Create(entitySet);

                context.Verify(m => m.SaveChanges(), Times.Once);
            }
        }

        [TestFixture]
        class Read
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var database = new Mock<IScheduleDatabase>();
                var gateway = new ScheduleStorageGateway<Association>(database.Object);

                Assert.Throws<ArgumentNullException>(() => gateway.Read(null));
            }

            [Test]
            public void returns_expected_result()
            {
                var database = new Mock<IScheduleDatabase>();
                var context = new Mock<IScheduleContext>();

                var entitySet = new List<Association>
                {
                    new Association
                    {
                        Id = 5,
                        MainTrainUid = "train"
                    },
                    new Association
                    {
                        Id = 7,
                        MainTrainUid = "supreme"
                    }
                };

                context.Setup(m => m.GetSet<Association>()).Returns(MockHelpers.BuildMockSet(entitySet).Object);

                database.Setup(m => m.BuildContext()).Returns(context.Object);

                var gateway = new ScheduleStorageGateway<Association>(database.Object);

                var result = gateway.Read(x => x.Id == 5);

                Assert.AreEqual(1, result.Count);
                Assert.AreEqual("train", result[0].MainTrainUid);
            }
        }

        [TestFixture]
        class Destroy
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var database = new Mock<IScheduleDatabase>();
                var gateway = new ScheduleStorageGateway<Association>(database.Object);

                Assert.Throws<ArgumentNullException>(() => gateway.Destroy(null));
            }

            [Test]
            public void calls_save_changes_on_context()
            {
                var database = new Mock<IScheduleDatabase>();
                var context = new Mock<IScheduleContext>();

                var entitySet = new List<Association>();

                context.Setup(m => m.GetSet<Association>()).Returns(MockHelpers.BuildMockSet(entitySet).Object);

                database.Setup(m => m.BuildContext()).Returns(context.Object);

                var gateway = new ScheduleStorageGateway<Association>(database.Object);

                gateway.Destroy(entitySet);

                context.Verify(m => m.SaveChanges(), Times.Once);
            }
        }
    }
}
