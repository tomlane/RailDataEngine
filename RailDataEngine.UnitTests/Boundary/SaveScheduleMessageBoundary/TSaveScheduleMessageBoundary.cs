using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Boundary.Schedule.SaveScheduleMessageBoundary;
using RailDataEngine.Domain.Interactor.SaveScheduleMessageInteractor;

namespace RailDataEngine.UnitTests.Boundary.SaveScheduleMessageBoundary
{
    [TestFixture]
    class TSaveScheduleMessageBoundary
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var interactorMock = new Mock<ISaveScheduleMessagesInteractor>();

            Assert.Throws<ArgumentNullException>(() => new Core.Boundary.Schedule.SaveScheduleMessageBoundary(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<ISaveScheduleMessagesBoundary>();
            Assert.IsInstanceOf<Core.Boundary.Schedule.SaveScheduleMessageBoundary>(boundary);
        }

        [TestFixture]
        class Invoke
        {
            [Test]
            public void calls_interactor()
            {
                var interactorMock = new Mock<ISaveScheduleMessagesInteractor>();

                var boundary = new Core.Boundary.Schedule.SaveScheduleMessageBoundary(interactorMock.Object);

                boundary.Invoke(new SaveScheduleBoundaryRequest
                {
                    MessagesToSave = new List<string>
                    {
                        "hello"
                    }
                });

                interactorMock.Verify(m => m.SaveScheduleMessages(It.IsAny<SaveScheduleMessageInteractorRequest>()), Times.Once);
            }
        }
    }
}
