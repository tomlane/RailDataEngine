using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.DI;
using RailDataEngine.Domain.Boundary.TrainMovements.SaveMovementMessageBoundary;
using RailDataEngine.Domain.Interactor.SaveMovementMessageInteractor;

namespace RailDataEngine.Boundary.Tests.SaveMovementMessageBoundary
{
    [TestFixture]
    class TSaveMovementMessageBoundary
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var interactorMock = new Mock<ISaveMovementMessageInteractor>();

            Assert.Throws<ArgumentNullException>(
                () => new Implementations.TrainMovements.SaveMovementMessageBoundary(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<ISaveMovementMessageBoundary>();
            Assert.IsInstanceOf<Implementations.TrainMovements.SaveMovementMessageBoundary>(boundary);
        }
    }
}
