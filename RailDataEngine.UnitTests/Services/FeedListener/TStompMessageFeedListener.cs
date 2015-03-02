using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Boundary.TrainDescriber.ProcessDescriberMessageBoundary;
using RailDataEngine.Domain.Boundary.TrainMovements.ProcessMovementMessageBoundary;
using RailDataEngine.Domain.Services.FeedListenerService;
using RailDataEngine.Services.FeedListener;

namespace RailDataEngine.UnitTests.Services.FeedListener
{
    [TestFixture]
    class TStompMessageFeedListener
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var movementMessageBoundary = new Mock<IProcessMovementMessageBoundary>();
            var describerMessageBoundary = new Mock<IProcessDescriberMessageBoundary>();

            Assert.Throws<ArgumentNullException>(() => new StompMessageFeedListener(null, describerMessageBoundary.Object));
            Assert.Throws<ArgumentNullException>(() => new StompMessageFeedListener(movementMessageBoundary.Object, null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var listener = container.Resolve<IMessageFeedListener>();
            Assert.IsInstanceOf<StompMessageFeedListener>(listener);
        }
    }
}
