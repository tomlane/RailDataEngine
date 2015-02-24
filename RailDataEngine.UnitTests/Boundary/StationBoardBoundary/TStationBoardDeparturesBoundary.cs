using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Core.Boundary.StationBoard;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardDeparturesBoundary;
using RailDataEngine.Domain.Entity.StationBoard;
using RailDataEngine.Domain.Interactor.StationBoardInteractor;

namespace RailDataEngine.UnitTests.Boundary.StationBoardBoundary
{
    [TestFixture]
    class TStationBoardDeparturesBoundary
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var interactor = new Mock<IStationBoardInteractor>();

            Assert.Throws<ArgumentNullException>(() => new StationBoardDeparturesBoundary(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<IStationBoardDeparturesBoundary>();
            Assert.IsInstanceOf<StationBoardDeparturesBoundary>(boundary);
        }

        [TestFixture]
        class Invoke
        {
            [Test]
            public void calls_interactor()
            {
                var interactor = new Mock<IStationBoardInteractor>();

                interactor.Setup(m => m.GetDepartures(It.IsAny<StationBoardDeparturesInteractorRequest>()))
                    .Returns(new StationBoardDeparturesInteractorResponse());

                var boundary = new StationBoardDeparturesBoundary(interactor.Object);

                boundary.Invoke(new StationBoardDeparturesBoundaryRequest
                {
                    Crs = "swi"
                });

                interactor.Verify(m => m.GetDepartures(It.IsAny<StationBoardDeparturesInteractorRequest>()), Times.Once);
            }

            [Test]
            public void returns_expected_result()
            {
                var stationBoardInteractor = new Mock<IStationBoardInteractor>();

                var mockDeparture = new StationBoardDeparturesInteractorResponse
                {
                    Services = new List<Departure>
                    {
                        new Departure
                        {
                            Operator = "First Great Western",
                            Platform = "4"
                        }
                    },
                    StationName = "Swindon"
                };
                stationBoardInteractor.Setup(m => m.GetDepartures(It.IsAny<StationBoardDeparturesInteractorRequest>()))
                    .Returns(mockDeparture);

                var boundary = new StationBoardDeparturesBoundary(stationBoardInteractor.Object);

                var response = boundary.Invoke(new StationBoardDeparturesBoundaryRequest
                {
                    Crs = "swi"
                });

                Assert.AreEqual(mockDeparture.Services.Count, response.Services.Count);
                Assert.AreEqual(mockDeparture.StationName, response.StationName);
            }
        }
    }
}
