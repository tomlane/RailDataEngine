using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Boundary.TrainMovements.ProcessMovementMessageBoundary;
using RailDataEngine.Domain.Interactor.ProcessMovementMessageInteractor;

namespace RailDataEngine.UnitTests.Boundary.SaveMovementMessageBoundary
{
    [TestFixture]
    class TSaveMovementMessageBoundary
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var interactorMock = new Mock<IProcessMovementMessageInteractor>();

            Assert.Throws<ArgumentNullException>(
                () => new Core.Boundary.TrainMovements.ProcessMovementMessageBoundary(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<IProcessMovementMessageBoundary>();
            Assert.IsInstanceOf<Core.Boundary.TrainMovements.ProcessMovementMessageBoundary>(boundary);
        }

        [TestFixture]
        class Invoke
        {
            [Test]
            public void calls_interactor()
            {
                var interactorMock = new Mock<IProcessMovementMessageInteractor>();

                var boundary = new Core.Boundary.TrainMovements.ProcessMovementMessageBoundary(interactorMock.Object);

                boundary.Invoke(new ProcessMovementMessageBoundaryRequest
                {
                    MessageToSave = "{ JSON }"
                });

                interactorMock.Verify(m => m.ProcessMovementMessages(It.IsAny<ProcessMovementMessageInteractorRequest>()), Times.Once());
            }
        }
    }
}
