using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Boundary.TrainMovements.FetchCancellationsBoundary;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Interactor.FetchCancellationsInteractor;

namespace RailDataEngine.UnitTests.Boundary.FetchCancellationsBoundary
{
    [TestFixture]
    class TFetchCancellationsBoundary
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var interactor = new Mock<IFetchCancellationsInteractor>();

            Assert.Throws<ArgumentNullException>(() => new Core.Boundary.TrainMovements.FetchCancellationsBoundary(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<IFetchCancellationsBoundary>();
            Assert.IsInstanceOf<Core.Boundary.TrainMovements.FetchCancellationsBoundary>(boundary);
        }

        [TestFixture]
        class Invoke
        {
            [Test]
            public void calls_interactor()
            {
                var interactor = new Mock<IFetchCancellationsInteractor>();

                interactor.Setup(m => m.FetchCancellations(It.IsAny<FetchCancellationsInteractorRequest>()))
                    .Returns(new FetchCancellationsInteractorResponse
                    {
                        Cancellations = new List<TrainCancellation>()
                    });

                var boundary = new Core.Boundary.TrainMovements.FetchCancellationsBoundary(interactor.Object);

                boundary.Invoke(new FetchCancellationsBoundaryRequest
                {
                    Date = new DateTime(2015, 02, 27, 14, 30, 0)
                });

                interactor.Verify(m => m.FetchCancellations(It.IsAny<FetchCancellationsInteractorRequest>()), Times.Once);
            }

            [Test]
            public void returns_result_from_interactor()
            {
                var interactor = new Mock<IFetchCancellationsInteractor>();

                var fetchActivationsInteractorResponse = new FetchCancellationsInteractorResponse
                {
                    Cancellations = new List<TrainCancellation>
                    {
                        new TrainCancellation
                        {
                            TrainId = "trainId"
                        }
                    }
                };

                interactor.Setup(m => m.FetchCancellations(It.IsAny<FetchCancellationsInteractorRequest>()))
                    .Returns(fetchActivationsInteractorResponse);

                var boundary = new Core.Boundary.TrainMovements.FetchCancellationsBoundary(interactor.Object);

                var result = boundary.Invoke(new FetchCancellationsBoundaryRequest
                {
                    Date = new DateTime(2015, 02, 27, 14, 30, 0)
                });

                Assert.AreEqual(result.Cancellations, fetchActivationsInteractorResponse.Cancellations);
            }
        }
    }
}
