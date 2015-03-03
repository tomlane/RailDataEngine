using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Api.Controllers;
using RailDataEngine.Core;
using RailDataEngine.Domain.Boundary.TrainMovements.FetchActivationsBoundary;
using RailDataEngine.Domain.Boundary.TrainMovements.FetchCancellationsBoundary;
using RailDataEngine.Domain.Boundary.TrainMovements.FetchServiceMovementsBoundary;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.UnitTests.Api.Controllers
{
    [TestFixture]
    class TTrainMovementController
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var serviceMovementsBoundary = new Mock<IFetchServiceMovementsBoundary>();
            var activationsBoundary = new Mock<IFetchActivationsBoundary>();
            var cancellationsBoundary = new Mock<IFetchCancellationsBoundary>();

            Assert.Throws<ArgumentNullException>(() => new TrainMovementController(null, cancellationsBoundary.Object, serviceMovementsBoundary.Object));
            Assert.Throws<ArgumentNullException>(() => new TrainMovementController(activationsBoundary.Object, null, serviceMovementsBoundary.Object));
            Assert.Throws<ArgumentNullException>(() => new TrainMovementController(activationsBoundary.Object, cancellationsBoundary.Object, null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();

            var controller = container.Resolve<TrainMovementController>();

            Assert.IsInstanceOf<TrainMovementController>(controller);
        }

        [TestFixture]
        class Activations
        {
            [Test]
            public void calls_boundary()
            {
                var serviceMovementsBoundary = new Mock<IFetchServiceMovementsBoundary>();
                var activationsBoundary = new Mock<IFetchActivationsBoundary>();
                var cancellationsBoundary = new Mock<IFetchCancellationsBoundary>();

                activationsBoundary.Setup(m => m.Invoke(It.IsAny<FetchActivationsBoundaryRequest>()))
                    .Returns(new FetchActivationsBoundaryResponse
                    {
                        Activations = new List<TrainActivation>()
                    });

                var controller = new TrainMovementController(activationsBoundary.Object, cancellationsBoundary.Object, serviceMovementsBoundary.Object);

                controller.Activations();

                activationsBoundary.Verify(m => m.Invoke(It.IsAny<FetchActivationsBoundaryRequest>()));
            }

            [Test]
            public void returns_result_from_boundary()
            {
                var serviceMovementsBoundary = new Mock<IFetchServiceMovementsBoundary>();
                var activationsBoundary = new Mock<IFetchActivationsBoundary>();
                var cancellationsBoundary = new Mock<IFetchCancellationsBoundary>();

                var fetchActivationsBoundaryResponse = new FetchActivationsBoundaryResponse
                {
                    Activations = new List<TrainActivation>
                    {
                        new TrainActivation
                        {
                            TrainUid = "myTrainId",
                            OriginStanox = "1337"
                        }    
                    }
                };

                activationsBoundary.Setup(m => m.Invoke(It.IsAny<FetchActivationsBoundaryRequest>()))
                    .Returns(fetchActivationsBoundaryResponse);

                var controller = new TrainMovementController(activationsBoundary.Object, cancellationsBoundary.Object, serviceMovementsBoundary.Object);

                var result = controller.Activations();

                Assert.AreEqual(fetchActivationsBoundaryResponse.Activations, result.Activations);
            }
        }

        [TestFixture]
        class Cancellations
        {
            [Test]
            public void calls_boundary()
            {
                var serviceMovementsBoundary = new Mock<IFetchServiceMovementsBoundary>();
                var activationsBoundary = new Mock<IFetchActivationsBoundary>();
                var cancellationsBoundary = new Mock<IFetchCancellationsBoundary>();

                cancellationsBoundary.Setup(m => m.Invoke(It.IsAny<FetchCancellationsBoundaryRequest>()))
                    .Returns(new FetchCancellationsBoundaryResponse
                    {
                        Cancellations = new List<TrainCancellation>()
                    });

                var controller = new TrainMovementController(activationsBoundary.Object, cancellationsBoundary.Object, serviceMovementsBoundary.Object);

                controller.Cancellations();

                cancellationsBoundary.Verify(m => m.Invoke(It.IsAny<FetchCancellationsBoundaryRequest>()));
            }

            [Test]
            public void returns_result_from_boundary()
            {
                var serviceMovementsBoundary = new Mock<IFetchServiceMovementsBoundary>();
                var activationsBoundary = new Mock<IFetchActivationsBoundary>();
                var cancellationsBoundary = new Mock<IFetchCancellationsBoundary>();

                var fetchCanellcationsBoundaryResponse = new FetchCancellationsBoundaryResponse
                {
                    Cancellations = new List<TrainCancellation>
                    {
                        new TrainCancellation
                        {
                            TrainId = "trainId",
                            OriginalLocationStanox = "1350"
                        }    
                    }
                };

                cancellationsBoundary.Setup(m => m.Invoke(It.IsAny<FetchCancellationsBoundaryRequest>()))
                    .Returns(fetchCanellcationsBoundaryResponse);

                var controller = new TrainMovementController(activationsBoundary.Object, cancellationsBoundary.Object, serviceMovementsBoundary.Object);

                var result = controller.Cancellations();

                Assert.AreEqual(fetchCanellcationsBoundaryResponse.Cancellations, result.Cancellations);
            }
        }

        [TestFixture]
        class ServiceMovements
        {
            [Test]
            public void throws_when_request_is_null()
            {
                var serviceMovementsBoundary = new Mock<IFetchServiceMovementsBoundary>();
                var activationsBoundary = new Mock<IFetchActivationsBoundary>();
                var cancellationsBoundary = new Mock<IFetchCancellationsBoundary>();

                var controller = new TrainMovementController(activationsBoundary.Object, cancellationsBoundary.Object, serviceMovementsBoundary.Object);

                Assert.Throws<ArgumentNullException>(() => controller.ServiceMovements(null));
            }

            [Test]
            public void calls_boundary()
            {
                var serviceMovementsBoundary = new Mock<IFetchServiceMovementsBoundary>();
                var activationsBoundary = new Mock<IFetchActivationsBoundary>();
                var cancellationsBoundary = new Mock<IFetchCancellationsBoundary>();

                serviceMovementsBoundary.Setup(m => m.Invoke(It.IsAny<FetchServiceMovementsBoundaryRequest>()))
                    .Returns(new FetchServiceMovementsBoundaryResponse
                    {
                        Activation = new TrainActivation(),
                        Cancellation = new TrainCancellation(),
                        Movements = new List<TrainMovement>()
                    });

                var controller = new TrainMovementController(activationsBoundary.Object, cancellationsBoundary.Object, serviceMovementsBoundary.Object);

                controller.ServiceMovements("trainId");

                serviceMovementsBoundary.Verify(m => m.Invoke(It.Is<FetchServiceMovementsBoundaryRequest>(x => x.TrainId == "trainId")));
            }

            [Test]
            public void returns_result_from_boundary()
            {
                var serviceMovementsBoundary = new Mock<IFetchServiceMovementsBoundary>();
                var activationsBoundary = new Mock<IFetchActivationsBoundary>();
                var cancellationsBoundary = new Mock<IFetchCancellationsBoundary>();

                var fetchServiceMovementsBoundaryResponse = new FetchServiceMovementsBoundaryResponse
                {
                    Activation = new TrainActivation
                    {
                        TrainUid = "myTrainId",
                        OriginStanox = "1337"
                    },
                    Cancellation = new TrainCancellation
                    {
                        TrainId = "myTrainId",
                        OriginalLocationStanox = "1337"
                    },
                    Movements = new List<TrainMovement>
                    {
                        new TrainMovement
                        {
                            TrainId = "myTrainId",
                            ReportingStanox = "1338",
                            OriginalLocationStanox = "1337"
                        }
                    }
                };

                serviceMovementsBoundary.Setup(m => m.Invoke(It.IsAny<FetchServiceMovementsBoundaryRequest>()))
                    .Returns(fetchServiceMovementsBoundaryResponse);

                var controller = new TrainMovementController(activationsBoundary.Object, cancellationsBoundary.Object, serviceMovementsBoundary.Object);

                var result  = controller.ServiceMovements("trainId");

                Assert.AreEqual(fetchServiceMovementsBoundaryResponse.Activation, result.Activation);
                Assert.AreEqual(fetchServiceMovementsBoundaryResponse.Cancellation, result.Cancellation);
                Assert.AreEqual(fetchServiceMovementsBoundaryResponse.Movements, result.Movements);
            }
        }
    }
}
