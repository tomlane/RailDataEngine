using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Data.TrainMovements;
using RailDataEngine.DI;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Gateway;
using RailDataEngine.Tests.Common;

namespace RailDataEngine.Gateway.EF.Tests
{
    [TestFixture]
    class TTrainMovementStorageGateway
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var database = new Mock<ITrainMovementDatabase>();

            Assert.Throws<ArgumentNullException>(() => new TrainMovementStorageGateway<TrainActivation>(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var gateway = container.Resolve<ITrainMovementStorageGateway<TrainActivation>>();
            Assert.IsInstanceOf<TrainMovementStorageGateway<TrainActivation>>(gateway);
        }

        [TestFixture]
        class Create
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var database = new Mock<ITrainMovementDatabase>();
                var gateway = new TrainMovementStorageGateway<TrainActivation>(database.Object);

                Assert.Throws<ArgumentNullException>(() => gateway.Create(null));
            }

            [Test]
            public void calls_save_changes_on_context()
            {
                var database = new Mock<ITrainMovementDatabase>();
                var context = new Mock<ITrainMovementContext>();

                var entitySet = new List<TrainActivation>();

                context.Setup(m => m.GetSet<TrainActivation>()).Returns(MockHelpers.BuildMockSet(entitySet).Object);

                database.Setup(m => m.BuildContext()).Returns(context.Object);

                var gateway = new TrainMovementStorageGateway<TrainActivation>(database.Object);

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
                var database = new Mock<ITrainMovementDatabase>();
                var gateway = new TrainMovementStorageGateway<TrainActivation>(database.Object);

                Assert.Throws<ArgumentNullException>(() => gateway.Read(null));
            }

            [Test]
            public void returns_expected_result()
            {
                var database = new Mock<ITrainMovementDatabase>();
                var context = new Mock<ITrainMovementContext>();

                var entitySet = new List<TrainActivation>
                {
                    new TrainActivation
                    {
                        Id = 5,
                        TrainId = "train"
                    },
                    new TrainActivation
                    {
                        Id = 7,
                        TrainId = "supreme"
                    }
                };

                context.Setup(m => m.GetSet<TrainActivation>()).Returns(MockHelpers.BuildMockSet(entitySet).Object);

                database.Setup(m => m.BuildContext()).Returns(context.Object);

                var gateway = new TrainMovementStorageGateway<TrainActivation>(database.Object);

                var result = gateway.Read(x => x.Id == 5);

                Assert.AreEqual(1, result.Count);
                Assert.AreEqual("train", result[0].TrainId);
            }
        }

        [TestFixture]
        class Destroy
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var database = new Mock<ITrainMovementDatabase>();
                var gateway = new TrainMovementStorageGateway<TrainActivation>(database.Object);

                Assert.Throws<ArgumentNullException>(() => gateway.Destroy(null));
            }

            [Test]
            public void calls_save_changes_on_context()
            {
                var database = new Mock<ITrainMovementDatabase>();
                var context = new Mock<ITrainMovementContext>();

                var entitySet = new List<TrainActivation>();

                context.Setup(m => m.GetSet<TrainActivation>()).Returns(MockHelpers.BuildMockSet(entitySet).Object);

                database.Setup(m => m.BuildContext()).Returns(context.Object);

                var gateway = new TrainMovementStorageGateway<TrainActivation>(database.Object);

                gateway.Destroy(entitySet);

                context.Verify(m => m.SaveChanges(), Times.Once);
            }
        }
    }
}
