using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.DI;
using RailDataEngine.Domain.Boundary.TrainMovements.SaveMovementMessageBoundary;
using RailDataEngine.Domain.Services.FeedListenerService;
using RailDataEngine.Services.FeedListener;

namespace RailDataEngine.UnitTests.Services.FeedListener
{
    [TestFixture]
    class TTrainMovementListener
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var boundaryMock = new Mock<ISaveMovementMessageBoundary>();

            Assert.Throws<ArgumentNullException>(() => new StompTrainMovementListener(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var listener = container.Resolve<ITrainMovementListener>();
            Assert.IsInstanceOf<StompTrainMovementListener>(listener);
        }
    }
}
