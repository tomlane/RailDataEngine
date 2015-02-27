using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Boundary.TrainMovements.FetchActivationsBoundary;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Interactor.FetchActivationsInteractor;

namespace RailDataEngine.UnitTests.Boundary.FetchActivationsBoundary
{
    [TestFixture]
    class TFetchActivationsBoundary
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var interactor = new Mock<IFetchActivationsInteractor>();

            Assert.Throws<ArgumentNullException>(() => new Core.Boundary.TrainMovements.FetchActivationsBoundary(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<IFetchActivationsBoundary>();
            Assert.IsInstanceOf<Core.Boundary.TrainMovements.FetchActivationsBoundary>(boundary);
        }

        [TestFixture]
        class Invoke
        {
            [Test]
            public void calls_interactor()
            {
                var interactor = new Mock<IFetchActivationsInteractor>();

                interactor.Setup(m => m.FetchActivations(It.IsAny<FetchActivationsInteractorRequest>()))
                    .Returns(new FetchActivationsInteractorResponse
                    {
                        Activations = new List<TrainActivation>()
                    });

                var boundary = new Core.Boundary.TrainMovements.FetchActivationsBoundary(interactor.Object);

                boundary.Invoke(new FetchActivationsBoundaryRequest
                {
                    Date = new DateTime(2015, 02, 27, 14, 30, 0)
                });

                interactor.Verify(m => m.FetchActivations(It.IsAny<FetchActivationsInteractorRequest>()), Times.Once);
            }

            [Test]
            public void returns_result_from_interactor()
            {
                var interactor = new Mock<IFetchActivationsInteractor>();

                var fetchActivationsInteractorResponse = new FetchActivationsInteractorResponse
                {
                    Activations = new List<TrainActivation>
                    {
                        new TrainActivation
                        {
                            TrainId = "trainId"
                        }
                    }
                };

                interactor.Setup(m => m.FetchActivations(It.IsAny<FetchActivationsInteractorRequest>()))
                    .Returns(fetchActivationsInteractorResponse);

                var boundary = new Core.Boundary.TrainMovements.FetchActivationsBoundary(interactor.Object);

                var result = boundary.Invoke(new FetchActivationsBoundaryRequest
                {
                    Date = new DateTime(2015, 02, 27, 14, 30, 0)
                });

                Assert.AreEqual(result.Activations, fetchActivationsInteractorResponse.Activations);
            }
        }
    }
}
