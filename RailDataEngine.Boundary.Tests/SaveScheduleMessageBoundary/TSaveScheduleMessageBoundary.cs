using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.DI;
using RailDataEngine.Domain.Boundary.Schedule.SaveScheduleMessageBoundary;
using RailDataEngine.Domain.Interactor.SaveScheduleMessageInteractor;

namespace RailDataEngine.Boundary.Tests.SaveScheduleMessageBoundary
{
    [TestFixture]
    class TSaveScheduleMessageBoundary
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var interactorMock = new Mock<ISaveScheduleMessagesInteractor>();

            Assert.Throws<ArgumentNullException>(() => new Implementations.Schedule.SaveScheduleMessageBoundary(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<ISaveScheduleMessagesBoundary>();
            Assert.IsInstanceOf<Implementations.Schedule.SaveScheduleMessageBoundary>(boundary);
        }

        [TestFixture]
        class Invoke
        {
            [Test]
            public void calls_interactor()
            {
                var interactorMock = new Mock<ISaveScheduleMessagesInteractor>();

                var boundary = new Implementations.Schedule.SaveScheduleMessageBoundary(interactorMock.Object);

                boundary.Invoke(new SaveScheduleBoundaryRequest
                {
                    MessageToSave = "{ json }"
                });

                interactorMock.Verify(m => m.SaveScheduleMessages(It.IsAny<SaveScheduleMessageInteractorRequest>()), Times.Once);
            }
        }
    }
}
