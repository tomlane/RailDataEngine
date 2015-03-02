using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Boundary.Schedule.ProcessScheduleMessageBoundary;
using RailDataEngine.Domain.Interactor.ProcessScheduleMessageInteractor;

namespace RailDataEngine.UnitTests.Boundary.SaveScheduleMessageBoundary
{
    [TestFixture]
    class TSaveScheduleMessageBoundary
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var interactorMock = new Mock<IProcessScheduleMessageInteractor>();

            Assert.Throws<ArgumentNullException>(() => new Core.Boundary.Schedule.ProcessScheduleMessageBoundary(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<IProcessScheduleMessageBoundary>();
            Assert.IsInstanceOf<Core.Boundary.Schedule.ProcessScheduleMessageBoundary>(boundary);
        }

        [TestFixture]
        class Invoke
        {
            [Test]
            public void calls_interactor()
            {
                var interactorMock = new Mock<IProcessScheduleMessageInteractor>();

                var boundary = new Core.Boundary.Schedule.ProcessScheduleMessageBoundary(interactorMock.Object);

                boundary.Invoke(new ProcessScheduleBoundaryRequest
                {
                    MessagesToSave = new List<string>
                    {
                        "hello"
                    }
                });

                interactorMock.Verify(m => m.ProcessScheduleMessages(It.IsAny<ProcessScheduleMessageInteractorRequest>()), Times.Once);
            }
        }
    }
}
