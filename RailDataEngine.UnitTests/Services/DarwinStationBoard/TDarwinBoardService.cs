﻿using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Exception;
using RailDataEngine.Domain.Services.StationBoardService;
using RailDataEngine.Services.DarwinStationBoard;
using RailDataEngine.Services.DarwinStationBoard.DarwinServiceReference;
using CallingPoint = RailDataEngine.Services.DarwinStationBoard.DarwinServiceReference.CallingPoint;
using ServiceDetails = RailDataEngine.Services.DarwinStationBoard.DarwinServiceReference.ServiceDetails;

namespace RailDataEngine.UnitTests.Services.DarwinStationBoard
{
    [TestFixture]
    class TDarwinBoardService
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var darwinService = new Mock<LDBServiceSoap>();

            Assert.Throws<ArgumentNullException>(() => new DarwinBoardService(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var service = container.Resolve<IStationBoardService>();
            Assert.IsInstanceOf<DarwinBoardService>(service);
        }

        [TestFixture]
        private class GetArrivals
        {
            [Test]
            public void throws_when_crs_is_null()
            {
                var soapServiceMock = new Mock<LDBServiceSoap>();

                var service = new DarwinBoardService(soapServiceMock.Object);
                Assert.Throws<ArgumentNullException>(() => service.GetArrivals(new StationBoardRequest()));
            }

            [Test]
            public void calls_soap_service()
            {
                var soapServiceMock = new Mock<LDBServiceSoap>();

                soapServiceMock.Setup(m => m.GetArrivalBoard(It.IsAny<GetArrivalBoardRequest>()))
                    .Returns(new GetArrivalBoardResponse
                    {
                        GetStationBoardResult = new StationBoard
                        {
                            locationName = "Swindon",
                            generatedAt = new DateTime(2015, 11, 11),
                            trainServices = new ServiceItem[] { }
                        }
                    });

                var service = new DarwinBoardService(soapServiceMock.Object);

                service.GetArrivals(new StationBoardRequest
                {
                    Crs = "swi"
                });

                soapServiceMock.Verify(m => m.GetArrivalBoard(It.IsAny<GetArrivalBoardRequest>()), Times.Once);
            }

            [Test]
            public void throws_when_result_is_null()
            {
                var soapServiceMock = new Mock<LDBServiceSoap>();

                var service = new DarwinBoardService(soapServiceMock.Object);

                Assert.Throws<NullServiceResultException>(() => service.GetArrivals(new StationBoardRequest
                {
                    Crs = "swi"
                }));
            }

            [Ignore]
            [Test]
            public void returns_expected_result()
            {
                var soapServiceMock = new Mock<LDBServiceSoap>();

                var serviceResponse = new GetArrivalBoardResponse
                {
                    GetStationBoardResult = new StationBoard
                    {
                        locationName = "Swindon",
                        crs = "SWI",
                        trainServices = new[]
                        {
                            new ServiceItem()
                            {
                                @operator = "First Great Western",
                                origin = new []{new ServiceLocation{ locationName = "London Paddington"} },
                                destination = new []{new ServiceLocation{ locationName = "Bristol Temple Meads"} },
                                eta = "On Time",
                                sta = "On Time",
                                platform = "4",
                                serviceID = "service990"
                            }
                        },
                        busServices = new[]
                        {
                            new ServiceItem()
                            {
                                @operator = "Bus Replacement Limited",
                                eta = "On Time",
                                etd = "On Time",
                                serviceID = "bus995"
                            }
                        },
                        ferryServices = new[]
                        {
                            new ServiceItem()
                            {
                                @operator = "Ferry To Where",
                                eta = "On Time",
                                etd = "On Time",
                                serviceID = "boat995"
                            }
                        },
                        areServicesAvailable = true
                    }
                };

                soapServiceMock.Setup(m => m.GetArrivalBoard(It.IsAny<GetArrivalBoardRequest>()))
                    .Returns(serviceResponse);

                var service = new DarwinBoardService(soapServiceMock.Object);
                var response = service.GetArrivals(new StationBoardRequest()
                {
                    Crs = "swi"
                });

                int totalServiceCount = serviceResponse.GetStationBoardResult.busServices.Length +
                                        serviceResponse.GetStationBoardResult.trainServices.Length +
                                        serviceResponse.GetStationBoardResult.ferryServices.Length;

                Assert.AreEqual(serviceResponse.GetStationBoardResult.locationName, response.StationName);
                Assert.AreEqual(totalServiceCount, response.Services.Count);
            }
        }

        [TestFixture]
        private class GetDepartures
        {
            [Test]
            public void throws_when_crs_is_null()
            {
                var soapServiceMock = new Mock<LDBServiceSoap>();

                var service = new DarwinBoardService(soapServiceMock.Object);
                Assert.Throws<ArgumentNullException>(() => service.GetDepartures(new StationBoardRequest()));

            }

            [Test]
            public void calls_soap_service()
            {
                var soapServiceMock = new Mock<LDBServiceSoap>();

                soapServiceMock.Setup(m => m.GetDepartureBoard(It.IsAny<GetDepartureBoardRequest>()))
                    .Returns(new GetDepartureBoardResponse
                    {
                        GetStationBoardResult = new StationBoard
                        {
                            locationName = "Swindon",
                            generatedAt = new DateTime(2014, 11, 11),
                            trainServices = new ServiceItem[] { }
                        }
                    });

                var service = new DarwinBoardService(soapServiceMock.Object);

                service.GetDepartures(new StationBoardRequest
                {
                    Crs = "swi"
                });

                soapServiceMock.Verify(m => m.GetDepartureBoard(It.IsAny<GetDepartureBoardRequest>()), Times.Once);
            }

            [Test]
            public void throws_when_result_is_null()
            {
                var soapServiceMock = new Mock<LDBServiceSoap>();
                
                var service = new DarwinBoardService(soapServiceMock.Object);

                Assert.Throws<NullServiceResultException>(() =>  service.GetDepartures(new StationBoardRequest
                {
                    Crs = "swi"
                }));
            }

            [Ignore]
            [Test]
            public void returns_expected_result()
            {
                var soapServiceMock = new Mock<LDBServiceSoap>();

                var serviceResponse = new GetDepartureBoardResponse
                {
                    GetStationBoardResult = new StationBoard
                    {
                        locationName = "Swindon",
                        crs = "SWI",
                        trainServices = new[]
                        {
                            new ServiceItem()
                            {
                                @operator = "First Great Western",
                                origin = new []{new ServiceLocation{ locationName = "London Paddington"} },
                                destination = new []{new ServiceLocation{ locationName = "Bristol Temple Meads"} },
                                eta = "On Time",
                                sta = "On Time",
                                platform = "4",
                                serviceID = "service990"
                            }
                        },
                        busServices = new[]
                        {
                            new ServiceItem()
                            {
                                @operator = "Bus Replacement Limited",
                                eta = "On Time",
                                etd = "On Time",
                                serviceID = "bus995"
                            }
                        },
                        ferryServices = new[]
                        {
                            new ServiceItem()
                            {
                                @operator = "Ferry To Where",
                                eta = "On Time",
                                etd = "On Time",
                                serviceID = "boat995"
                            }
                        },
                        areServicesAvailable = true
                    }
                };

                soapServiceMock.Setup(m => m.GetDepartureBoard(It.IsAny<GetDepartureBoardRequest>()))
                    .Returns(serviceResponse);

                var service = new DarwinBoardService(soapServiceMock.Object);
                var response = service.GetDepartures(new StationBoardRequest
                {
                    Crs = "swi"
                });

                int totalServiceCount = serviceResponse.GetStationBoardResult.busServices.Length +
                                        serviceResponse.GetStationBoardResult.trainServices.Length +
                                        serviceResponse.GetStationBoardResult.ferryServices.Length;

                Assert.AreEqual(serviceResponse.GetStationBoardResult.locationName, response.StationName);
                Assert.AreEqual(totalServiceCount, response.Services.Count);
            }
        }

        [TestFixture]
        private class GetServiceDetails
        {
            [Test]
            public void throws_when_crs_is_null()
            {
                var soapServiceMock = new Mock<LDBServiceSoap>();

                var service = new DarwinBoardService(soapServiceMock.Object);
                Assert.Throws<ArgumentNullException>(() => service.GetServiceDetails(new ServiceDetailsRequest()));
            }

            [Test]
            public void calls_soap_service()
            {
                var soapServiceMock = new Mock<LDBServiceSoap>();

                soapServiceMock.Setup(m => m.GetServiceDetails(It.IsAny<GetServiceDetailsRequest>()))
                    .Returns(GetServiceDetailsResponse());

                var service = new DarwinBoardService(soapServiceMock.Object);

                service.GetServiceDetails(new ServiceDetailsRequest
                {
                    ServiceId = "serviceId"
                });

                soapServiceMock.Verify(m => m.GetServiceDetails(It.IsAny<GetServiceDetailsRequest>()), Times.Once);
            }

            [Test]
            public void throws_when_result_is_null()
            {
                var soapServiceMock = new Mock<LDBServiceSoap>();

                var service = new DarwinBoardService(soapServiceMock.Object);

                Assert.Throws<NullServiceResultException>(() => service.GetServiceDetails(new ServiceDetailsRequest
                {
                    ServiceId = "serviceId"
                }));
            }

            [Test]
            public void returns_expected_result()
            {
                var soapServiceMock = new Mock<LDBServiceSoap>();

                var mockResponse = GetServiceDetailsResponse();

                soapServiceMock.Setup(m => m.GetServiceDetails(It.IsAny<GetServiceDetailsRequest>()))
                    .Returns(mockResponse);

                var service = new DarwinBoardService(soapServiceMock.Object);

                var response = service.GetServiceDetails(new ServiceDetailsRequest
                {
                    ServiceId = "serviceId"
                });

                Assert.AreEqual(mockResponse.GetServiceDetailsResult.crs, response.ServiceDetails.Crs);
                Assert.AreEqual(mockResponse.GetServiceDetailsResult.locationName, response.ServiceDetails.LocationName);
                Assert.AreEqual(mockResponse.GetServiceDetailsResult.@operator, response.ServiceDetails.Operator);

                Assert.AreEqual(
                    mockResponse.GetServiceDetailsResult.previousCallingPoints[0].callingPoint[0].locationName,
                    response.ServiceDetails.PreviousCallingPoints[0].LocationName);
                Assert.AreEqual(mockResponse.GetServiceDetailsResult.previousCallingPoints[0].callingPoint[0].at,
                    response.ServiceDetails.PreviousCallingPoints[0].ActualTime);
                Assert.AreEqual(mockResponse.GetServiceDetailsResult.previousCallingPoints[0].callingPoint[0].st,
                    response.ServiceDetails.PreviousCallingPoints[0].ScheduledTime);
                Assert.AreEqual(mockResponse.GetServiceDetailsResult.previousCallingPoints[0].callingPoint[0].et,
                    response.ServiceDetails.PreviousCallingPoints[0].EstimatedTime);
                Assert.AreEqual(mockResponse.GetServiceDetailsResult.previousCallingPoints[0].callingPoint[0].crs,
                    response.ServiceDetails.PreviousCallingPoints[0].Crs);
            }

            private static GetServiceDetailsResponse GetServiceDetailsResponse()
            {
                return new GetServiceDetailsResponse
                {
                    GetServiceDetailsResult = new ServiceDetails
                    {
                        @operator = "First Great Western",
                        crs = "SWI",
                        locationName = "Swindon",
                        subsequentCallingPoints = new[]
                        {
                            new ArrayOfCallingPoints()
                            {
                                callingPoint = new[]
                                {
                                    new CallingPoint()
                                    {
                                        crs = "cpm",
                                        locationName = "Chippenham",
                                        at = "10",
                                        et = "11",
                                        st = "12"
                                    },
                                    new CallingPoint()
                                    {
                                        crs = "trw",
                                        locationName = "Trowbridge",
                                        at = "13",
                                        et = "14",
                                        st = "15"
                                    }
                                }
                            }
                        },
                        previousCallingPoints = new[]
                        {
                            new ArrayOfCallingPoints()
                            {
                                callingPoint = new[]
                                {
                                    new CallingPoint()
                                    {
                                        crs = "oxd",
                                        locationName = "Oxford",
                                        at = "10",
                                        et = "11",
                                        st = "12"
                                    },
                                    new CallingPoint()
                                    {
                                        crs = "pad",
                                        locationName = "London Paddington",
                                        at = "13",
                                        et = "14",
                                        st = "15"
                                    }
                                }
                            }
                        },
                        generatedAt = new DateTime(2014, 11, 11, 15, 0, 0),
                        disruptionReason = "signalling problems",
                        overdueMessage = "No idea where this one is"
                    }
                };
            }
        }
    }
}
