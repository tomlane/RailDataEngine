using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Boundary.TrainMovements.FetchServiceMovementsBoundary;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Interactor.FetchServiceMovementsInteractor;

namespace RailDataEngine.UnitTests.Boundary.FetchServiceMovementsBoundary
{
    [TestFixture]
    class TFetchServiceMovementsBoundary
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var interactor = new Mock<IFetchServiceMovementsInteractor>();

            Assert.Throws<ArgumentNullException>(() => new Core.Boundary.TrainMovements.FetchServiceMovementsBoundary(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<IFetchServiceMovementsBoundary>();
            Assert.IsInstanceOf<Core.Boundary.TrainMovements.FetchServiceMovementsBoundary>(boundary);
        }

        [TestFixture]
        private class Invoke
        {
            [Test]
            public void calls_interactor()
            {
                var interactor = new Mock<IFetchServiceMovementsInteractor>();

                interactor.Setup(m => m.FetchServiceMovements(It.IsAny<FetchServiceMovementsInteractorRequest>()))
                    .Returns(new FetchServiceMovementsInteractorResponse
                    {
                        Activation = new TrainActivation(),
                        Cancellation = new TrainCancellation(),
                        Movements = new List<TrainMovement>()
                    });

                var boundary = new Core.Boundary.TrainMovements.FetchServiceMovementsBoundary(interactor.Object);

                boundary.Invoke(new FetchServiceMovementsBoundaryRequest
                {
                    Date = new DateTime(2015, 02, 27, 14, 30, 0)
                });

                interactor.Verify(m => m.FetchServiceMovements(It.IsAny<FetchServiceMovementsInteractorRequest>()),
                    Times.Once);
            }

            [Test]
            public void returns_result_from_interactor()
            {
                var interactor = new Mock<IFetchServiceMovementsInteractor>();

                var fetchActivationsInteractorResponse = new FetchServiceMovementsInteractorResponse
                {
                    Activation = new TrainActivation
                    {
                        TrainId = "trainId"
                    },
                    Cancellation = new TrainCancellation
                    {
                        TrainId = "trainId"
                    },
                    Movements = new List<TrainMovement>
                    {
                        new TrainMovement
                        {
                            TrainId = "train1"
                        },
                        new TrainMovement
                        {
                            TrainId = "train2"
                        }
                    }
                };

                interactor.Setup(m => m.FetchServiceMovements(It.IsAny<FetchServiceMovementsInteractorRequest>()))
                    .Returns(fetchActivationsInteractorResponse);

                var boundary = new Core.Boundary.TrainMovements.FetchServiceMovementsBoundary(interactor.Object);

                var result = boundary.Invoke(new FetchServiceMovementsBoundaryRequest
                {
                    Date = new DateTime(2015, 02, 27, 14, 30, 0)
                });

                Assert.AreEqual(result.Activation, fetchActivationsInteractorResponse.Activation);
                Assert.AreEqual(result.Cancellation, fetchActivationsInteractorResponse.Cancellation);
                Assert.AreEqual(result.Movements, fetchActivationsInteractorResponse.Movements);
            }
        }
    }
}
