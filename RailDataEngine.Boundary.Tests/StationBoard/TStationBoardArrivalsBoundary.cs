using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Boundary.Implementations.StationBoard;
using RailDataEngine.Boundary.StationBoard.StationBoardArrivalsBoundary;
using RailDataEngine.DI;
using RailDataEngine.Domain.Entity.StationBoard;
using RailDataEngine.Interactor.StationBoardInteractor;

namespace RailDataEngine.Boundary.Tests.StationBoard
{
    [TestFixture]
    class TStationBoardArrivalsBoundary
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var stationBoardInteractor = new Mock<IStationBoardInteractor>();

            Assert.Throws<ArgumentNullException>(() => new StationBoardArrivalsBoundary(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<IStationBoardArrivalsBoundary>();
            Assert.IsInstanceOf<StationBoardArrivalsBoundary>(boundary);
        }

        [TestFixture]
        class Invoke
        {
            [Test]
            public void calls_interactor()
            {
                var stationBoardInteractor = new Mock<IStationBoardInteractor>();

                stationBoardInteractor.Setup(m => m.GetArrivals(It.IsAny<StationBoardArrivalsInteractorRequest>()))
                    .Returns(new StationBoardArrivalsInteractorResponse
                    {
                        Services = new List<Arrival>()
                    });

                var boundary = new StationBoardArrivalsBoundary(stationBoardInteractor.Object);

                boundary.Invoke(new StationBoardArrivalsBoundaryRequest
                {
                    Crs = "swi"
                });

                stationBoardInteractor.Verify(m => m.GetArrivals(It.IsAny<StationBoardArrivalsInteractorRequest>()), Times.Once);
            }

            [Test]
            public void returns_expected_result()
            {
                var stationBoardInteractor = new Mock<IStationBoardInteractor>();

                var mockArrival = new StationBoardArrivalsInteractorResponse
                {
                    Services = new List<Arrival>
                    {
                        new Arrival
                        {
                            Operator = "First Great Western",
                            Platform = "4"
                        }
                    },
                    StationName = "Swindon"
                };
                stationBoardInteractor.Setup(m => m.GetArrivals(It.IsAny<StationBoardArrivalsInteractorRequest>()))
                    .Returns(mockArrival);

                var boundary = new StationBoardArrivalsBoundary(stationBoardInteractor.Object);

                var response = boundary.Invoke(new StationBoardArrivalsBoundaryRequest
                {
                    Crs = "swi"
                });

                Assert.AreEqual(mockArrival.Services.Count, response.Services.Count);
                Assert.AreEqual(mockArrival.StationName, response.StationName);
            }
        }
    }
}
