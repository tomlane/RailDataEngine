using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.DI;
using RailDataEngine.Domain.Boundary.TrainMovements.SaveMovementMessageBoundary;
using RailDataEngine.Domain.Interactor.SaveMovementMessageInteractor;

namespace RailDataEngine.UnitTests.Boundary.SaveMovementMessageBoundary
{
    [TestFixture]
    class TSaveMovementMessageBoundary
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var interactorMock = new Mock<ISaveMovementMessageInteractor>();

            Assert.Throws<ArgumentNullException>(
                () => new Core.Boundary.TrainMovements.SaveMovementMessageBoundary(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<ISaveMovementMessageBoundary>();
            Assert.IsInstanceOf<Core.Boundary.TrainMovements.SaveMovementMessageBoundary>(boundary);
        }

        [TestFixture]
        class Invoke
        {
            [Test]
            public void calls_interactor()
            {
                var interactorMock = new Mock<ISaveMovementMessageInteractor>();

                var boundary = new Core.Boundary.TrainMovements.SaveMovementMessageBoundary(interactorMock.Object);

                boundary.Invoke(new SaveMovementMessageBoundaryRequest
                {
                    MessageToSave = "{ JSON }"
                });

                interactorMock.Verify(m => m.SaveMovementMessages(It.IsAny<SaveMovementMessageInteractorRequest>()), Times.Once());
            }
        }
    }
}
