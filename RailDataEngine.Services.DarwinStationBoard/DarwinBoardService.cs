using System;
using System.Collections.Generic;
using System.Configuration;
using RailDataEngine.Domain.Entity.StationBoard;
using RailDataEngine.Domain.Exception;
using RailDataEngine.Domain.Services.StationBoardService;
using RailDataEngine.Services.DarwinStationBoard.DarwinServiceReference;
using CallingPoint = RailDataEngine.Domain.Entity.StationBoard.CallingPoint;
using ServiceDetails = RailDataEngine.Domain.Entity.StationBoard.ServiceDetails;
using ServiceType = RailDataEngine.Domain.Entity.StationBoard.ServiceType;

namespace RailDataEngine.Services.DarwinStationBoard
{
    public class DarwinBoardService : IStationBoardService
    {
        private readonly LDBServiceSoap _ldbService;
        private readonly AccessToken _accessToken;

        public DarwinBoardService(LDBServiceSoap ldbService)
        {
            if (ldbService == null) throw new ArgumentNullException("ldbService");
            _ldbService = ldbService;
            _accessToken = new AccessToken { TokenValue = ConfigurationManager.AppSettings["DarwinToken"] };
        }

        public StationArrivalResponse GetArrivals(StationBoardRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Crs))
                throw new ArgumentNullException("request", "The crs can not be null.");

            var serviceResponse = _ldbService.GetArrivalBoard(new GetArrivalBoardRequest
            {
                crs = request.Crs,
                AccessToken = _accessToken
            });

            if (serviceResponse == null || serviceResponse.GetStationBoardResult == null)
                throw new NullServiceResultException("Darwin SOAP service",
                    string.Format("Arrivals for {0}", request.Crs));

            var response = new StationArrivalResponse
            {
                StationName = serviceResponse.GetStationBoardResult.locationName,
                Services = new List<Arrival>()
            };

            if (serviceResponse.GetStationBoardResult.trainServices != null)
            {
                foreach (var trainService in serviceResponse.GetStationBoardResult.trainServices)
                {
                    response.Services.Add(new Arrival
                    {
                        Operator = trainService.@operator,
                        Origin = trainService.origin[0].locationName,
                        Destination = trainService.destination[0].locationName,
                        ScheduledArrival = trainService.sta,
                        EstimatedArrival = trainService.eta,
                        Platform = trainService.platform,
                        ServiceId = trainService.serviceID,
                        Type = ServiceType.Train
                    });
                }    
            }

            if (serviceResponse.GetStationBoardResult.ferryServices != null)
            {
                foreach (var ferryService in serviceResponse.GetStationBoardResult.ferryServices)
                {
                    response.Services.Add(new Arrival
                    {
                        Operator = ferryService.@operator,
                        Destination = ferryService.destination[0].locationName,
                        EstimatedArrival = ferryService.eta,
                        Origin = ferryService.origin[0].locationName,
                        Platform = ferryService.platform,
                        ScheduledArrival = ferryService.sta,
                        ServiceId = ferryService.serviceID,
                        Type = ServiceType.Ferry
                    });
                }
            }

            if (serviceResponse.GetStationBoardResult.busServices != null)
            {
                foreach (var serviceItem in serviceResponse.GetStationBoardResult.busServices)
                {
                    response.Services.Add(new Arrival
                    {
                        Destination = serviceItem.destination[0].locationName,
                        EstimatedArrival = serviceItem.eta,
                        Operator = serviceItem.@operator,
                        Origin = serviceItem.origin[0].locationName,
                        Platform = serviceItem.platform,
                        ScheduledArrival = serviceItem.sta,
                        ServiceId = serviceItem.serviceID,
                        Type = ServiceType.Bus
                    });
                }
            }

            return response;
        }

        public StationDepartureResponse GetDepartures(StationBoardRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Crs))
                throw new ArgumentNullException("request", "Crs can not be null.");

            var serviceResponse = _ldbService.GetDepartureBoard(new GetDepartureBoardRequest
            {
                crs = request.Crs,
                AccessToken = _accessToken
            });

            if (serviceResponse == null || serviceResponse.GetStationBoardResult == null)
                throw new NullServiceResultException("Darwin SOAP service",
                    string.Format("Departures for {0}", request.Crs));

            var response = new StationDepartureResponse
            {
                StationName = serviceResponse.GetStationBoardResult.locationName,
                Services = new List<Departure>()
            };


            if (serviceResponse.GetStationBoardResult.trainServices != null)
            {
                foreach (var trainService in serviceResponse.GetStationBoardResult.trainServices)
                {
                    response.Services.Add(new Departure
                    {
                        Operator = trainService.@operator,
                        Origin = trainService.origin[0].locationName,
                        Destination = trainService.destination[0].locationName,
                        ScheduledDeparture = trainService.std,
                        EstimatedDepature = trainService.etd,
                        Platform = trainService.platform,
                        ServiceId = trainService.serviceID,
                        Type = ServiceType.Train
                    });
                }    
            }

            if (serviceResponse.GetStationBoardResult.busServices != null)
            {
                foreach (var serviceItem in serviceResponse.GetStationBoardResult.busServices)
                {
                    response.Services.Add(new Departure
                    {
                        Destination = serviceItem.destination[0].locationName,
                        EstimatedDepature = serviceItem.etd,
                        Operator = serviceItem.@operator,
                        Origin = serviceItem.origin[0].locationName,
                        Platform = serviceItem.platform,
                        ScheduledDeparture = serviceItem.std,
                        ServiceId = serviceItem.serviceID,
                        Type = ServiceType.Bus
                    });
                }    
            }

            if (serviceResponse.GetStationBoardResult.ferryServices != null)
            {
                foreach (var ferryService in serviceResponse.GetStationBoardResult.ferryServices)
                {
                    response.Services.Add(new Departure
                    {
                        Destination = ferryService.destination[0].locationName,
                        EstimatedDepature = ferryService.etd,
                        Operator = ferryService.@operator,
                        Origin = ferryService.origin[0].locationName,
                        Platform = ferryService.platform,
                        ScheduledDeparture = ferryService.std,
                        ServiceId = ferryService.serviceID,
                        Type = ServiceType.Ferry
                    });
                }    
            }

            return response;
        }

        public ServiceDetailsResponse GetServiceDetails(ServiceDetailsRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.ServiceId))
                throw new ArgumentNullException("request", "Service id can not be null.");


            var serviceResponse = _ldbService.GetServiceDetails(new GetServiceDetailsRequest
            {
                AccessToken = _accessToken,
                serviceID = request.ServiceId
            });

            if (serviceResponse == null || serviceResponse.GetServiceDetailsResult == null)
                throw new NullServiceResultException("Darwin SOAP service",
                    string.Format("Service details for {0}", request.ServiceId));

            var response = new ServiceDetailsResponse
            {
                ServiceDetails = new ServiceDetails
                {
                    ActualArrivalTime = serviceResponse.GetServiceDetailsResult.ata,
                    ActualDepartureTime = serviceResponse.GetServiceDetailsResult.atd,
                    CallingPoints = new List<CallingPoint>(),
                    Cancelled = serviceResponse.GetServiceDetailsResult.isCancelled,
                    Crs = serviceResponse.GetServiceDetailsResult.crs,
                    DisruptionReason = serviceResponse.GetServiceDetailsResult.disruptionReason,
                    EstimatedArrivalTime = serviceResponse.GetServiceDetailsResult.eta,
                    EstimatedDepartureTime = serviceResponse.GetServiceDetailsResult.etd,
                    LocationName = serviceResponse.GetServiceDetailsResult.locationName,
                    Operator = serviceResponse.GetServiceDetailsResult.@operator,
                    OverdueMessage = serviceResponse.GetServiceDetailsResult.overdueMessage,
                    Platform = serviceResponse.GetServiceDetailsResult.platform,
                    PreviousCallingPoints = new List<CallingPoint>(),
                    ScheduledDepartureTime = serviceResponse.GetServiceDetailsResult.std,
                    ScheduledArrivalTime = serviceResponse.GetServiceDetailsResult.sta    
                }
                
            };

            if (serviceResponse.GetServiceDetailsResult.previousCallingPoints.Length > 0)
            {
                foreach (
                    var callingPoint in
                        serviceResponse.GetServiceDetailsResult.previousCallingPoints[0].callingPoint)
                {
                    response.ServiceDetails.PreviousCallingPoints.Add(new CallingPoint
                    {
                        ActualTime = callingPoint.at,
                        Crs = callingPoint.crs,
                        EstimatedTime = callingPoint.et,
                        LocationName = callingPoint.locationName,
                        ScheduledTime = callingPoint.st
                    });
                }
            }

            if (serviceResponse.GetServiceDetailsResult.subsequentCallingPoints.Length > 0)
            {
                foreach (
                    var callingPoint in
                        serviceResponse.GetServiceDetailsResult.subsequentCallingPoints[0].callingPoint)
                {
                    response.ServiceDetails.CallingPoints.Add(new CallingPoint
                    {
                        ActualTime = callingPoint.at,
                        Crs = callingPoint.crs,
                        EstimatedTime = callingPoint.et,
                        LocationName = callingPoint.locationName,
                        ScheduledTime = callingPoint.st
                    });
                }
            }
            return response;
        }
    }
}
