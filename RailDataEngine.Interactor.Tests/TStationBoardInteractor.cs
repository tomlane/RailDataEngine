using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.DI;
using RailDataEngine.Interactor.StationBoardInteractor;
using RailDataEngine.Services.StationBoardService;

namespace RailDataEngine.Interactor.Tests
{
    [TestFixture]
    class TStationBoardInteractor
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var stationBoardMock = new Mock<IStationBoardService>();

            Assert.Throws<ArgumentNullException>(() => new Implementations.StationBoardInteractor(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var interactor = container.Resolve<IStationBoardInteractor>();
            Assert.IsInstanceOf<Implementations.StationBoardInteractor>(interactor);
        }

        [TestFixture]
        class GetArrivals
        {
            [Test]
            public void calls_stationboard_service()
            {
                var stationBoardMock = new Mock<IStationBoardService>();

                stationBoardMock.Setup(m => m.GetArrivals(It.IsAny<StationBoardRequest>()))
                    .Returns(new StationArrivalResponse());

                var interactor = new Implementations.StationBoardInteractor(stationBoardMock.Object);

                interactor.GetArrivals(new StationBoardArrivalsInteractorRequest
                {
                    Crs = "swi"
                });

                stationBoardMock.Verify(m => m.GetArrivals(It.IsAny<StationBoardRequest>()), Times.Once);
            }
        }

        [TestFixture]
        class GetDepartures
        {
            [Test]
            public void calls_stationboard_service()
            {
                var stationBoardMock = new Mock<IStationBoardService>();

                stationBoardMock.Setup(m => m.GetDepartures(It.IsAny<StationBoardRequest>()))
                    .Returns(new StationDepartureResponse());

                var interactor = new Implementations.StationBoardInteractor(stationBoardMock.Object);

                interactor.GetDepartures(new StationBoardDeparturesInteractorRequest
                {
                    Crs = "swi"
                });

                stationBoardMock.Verify(m => m.GetDepartures(It.IsAny<StationBoardRequest>()), Times.Once);
            }
        }

        [TestFixture]
        class GetServiceDetails
        {
            [Test]
            public void calls_stationboard_service()
            {
                var stationBoardMock = new Mock<IStationBoardService>();

                stationBoardMock.Setup(m => m.GetServiceDetails(It.IsAny<ServiceDetailsRequest>()))
                    .Returns(new ServiceDetailsResponse());

                var interactor = new Implementations.StationBoardInteractor(stationBoardMock.Object);

                interactor.GetServiceDetails(new StationBoardServiceDetailsInteractorRequest
                {
                    ServiceId = "serviceId"
                });

                stationBoardMock.Verify(m => m.GetServiceDetails(It.IsAny<ServiceDetailsRequest>()), Times.Once);
            }
        }
    }
}
