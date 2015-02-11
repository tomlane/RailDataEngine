using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.DI;
using RailDataEngine.Domain.Entity.StationBoard;
using RailDataEngine.Domain.Interactor.StationBoardInteractor;
using RailDataEngine.Domain.Services.StationBoardService;

namespace RailDataEngine.UnitTests.Interactor
{
    [TestFixture]
    class TStationBoardInteractor
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var stationBoardMock = new Mock<IStationBoardService>();

            Assert.Throws<ArgumentNullException>(() => new RailDataEngine.Interactor.Implementations.StationBoardInteractor(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var interactor = container.Resolve<IStationBoardInteractor>();
            Assert.IsInstanceOf<RailDataEngine.Interactor.Implementations.StationBoardInteractor>(interactor);
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

                var interactor = new RailDataEngine.Interactor.Implementations.StationBoardInteractor(stationBoardMock.Object);

                interactor.GetArrivals(new StationBoardArrivalsInteractorRequest
                {
                    Crs = "swi"
                });

                stationBoardMock.Verify(m => m.GetArrivals(It.IsAny<StationBoardRequest>()), Times.Once);
            }

            [Test]
            public void returns_expected_result()
            {
                var stationBoardMock = new Mock<IStationBoardService>();

                var mockStationArrival = new StationArrivalResponse
                {
                    StationName = "Swindon",
                    Services = new List<Arrival>
                    {
                        new Arrival
                        {
                            Destination = "London Paddington",
                            EstimatedArrival = "1845",
                            ScheduledArrival = "1840",
                            Origin = "Bristol Temple Meads",
                            Operator = "First Great Western",
                            Platform = "3",
                            Type = ServiceType.Train,
                            ServiceId = "ghjkl"
                        }
                    }
                };

                stationBoardMock.Setup(m => m.GetArrivals(It.IsAny<StationBoardRequest>())).Returns(mockStationArrival);

                var interactor = new RailDataEngine.Interactor.Implementations.StationBoardInteractor(stationBoardMock.Object);

                var response = interactor.GetArrivals(new StationBoardArrivalsInteractorRequest
                {
                    Crs = "swi"
                });

                Assert.AreEqual(mockStationArrival.Services.Count, response.Services.Count);
                Assert.AreEqual(mockStationArrival.StationName, response.StationName);
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

                var interactor = new RailDataEngine.Interactor.Implementations.StationBoardInteractor(stationBoardMock.Object);

                interactor.GetDepartures(new StationBoardDeparturesInteractorRequest
                {
                    Crs = "swi"
                });

                stationBoardMock.Verify(m => m.GetDepartures(It.IsAny<StationBoardRequest>()), Times.Once);
            }

            [Test]
            public void returns_expected_result()
            {
                var stationBoardMock = new Mock<IStationBoardService>();

                var mockStationDeparture = new StationDepartureResponse
                {
                    StationName = "Swindon",
                    Services = new List<Departure>
                    {
                        new Departure
                        {
                            Destination = "London Paddington",
                            EstimatedDepature = "1845",
                            ScheduledDeparture = "1840",
                            Origin = "Bristol Temple Meads",
                            Operator = "First Great Western",
                            Platform = "3",
                            Type = ServiceType.Train,
                            ServiceId = "ghjkl"
                        }
                    }
                };

                stationBoardMock.Setup(m => m.GetDepartures(It.IsAny<StationBoardRequest>())).Returns(mockStationDeparture);

                var interactor = new RailDataEngine.Interactor.Implementations.StationBoardInteractor(stationBoardMock.Object);

                var response = interactor.GetDepartures(new StationBoardDeparturesInteractorRequest
                {
                    Crs = "swi"
                });

                Assert.AreEqual(mockStationDeparture.Services.Count, response.Services.Count);
                Assert.AreEqual(mockStationDeparture.StationName, response.StationName);
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

                var interactor = new RailDataEngine.Interactor.Implementations.StationBoardInteractor(stationBoardMock.Object);

                interactor.GetServiceDetails(new StationBoardServiceDetailsInteractorRequest
                {
                    ServiceId = "serviceId"
                });

                stationBoardMock.Verify(m => m.GetServiceDetails(It.IsAny<ServiceDetailsRequest>()), Times.Once);
            }

            [Test]
            public void returns_expected_result()
            {
                var stationBoardMock = new Mock<IStationBoardService>();

                var mockServiceDetails = GetServiceDetailsResponse();

                stationBoardMock.Setup(m => m.GetServiceDetails(It.IsAny<ServiceDetailsRequest>()))
                    .Returns(mockServiceDetails);

                var interactor = new RailDataEngine.Interactor.Implementations.StationBoardInteractor(stationBoardMock.Object);

                var response = interactor.GetServiceDetails(new StationBoardServiceDetailsInteractorRequest
                {
                    ServiceId = "thatService"
                });

                Assert.AreEqual(mockServiceDetails.ServiceDetails.CallingPoints.Count, response.ServiceDetails.CallingPoints.Count);
                Assert.AreEqual(mockServiceDetails.ServiceDetails.PreviousCallingPoints.Count, response.ServiceDetails.PreviousCallingPoints.Count);
                Assert.AreEqual(mockServiceDetails.ServiceDetails.Cancelled, response.ServiceDetails.Cancelled);
            }

            private ServiceDetailsResponse GetServiceDetailsResponse()
            {
                return new ServiceDetailsResponse
                {
                    ServiceDetails = new ServiceDetails
                    {
                        ActualArrivalTime = "1750",
                        CallingPoints = new List<CallingPoint>
                    {
                      new CallingPoint
                      {
                          EstimatedTime = "1820",
                          Crs = "rdg",
                          LocationName = "Reading",
                          ScheduledTime = "1815"
                      }
                    },
                        Cancelled = true,
                        Crs = "swi",
                        DisruptionReason = "signalling problems",
                        EstimatedDepartureTime = "1752",
                        LocationName = "Swindon",
                        Operator = "First Great Western",
                        Platform = "4",
                        PreviousCallingPoints = new List<CallingPoint>
                    {
                        new CallingPoint
                        {
                            ActualTime = "1720",
                            Crs = "kem",
                            LocationName = "Kemble",
                            ScheduledTime = "1720"
                        }
                    },
                        OverdueMessage = "haven't heard from this one",
                        ScheduledDepartureTime = "1745"
                    }
                };
            }
        }
    }
}
