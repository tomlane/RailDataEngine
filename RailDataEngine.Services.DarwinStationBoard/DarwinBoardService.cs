using System;
using System.Collections.Generic;
using System.Configuration;
using RailDataEngine.Domain.Entity.StationBoard;
using RailDataEngine.Services.DarwinStationBoard.DarwinServiceReference;
using RailDataEngine.Services.Exception;
using RailDataEngine.Services.StationBoardService;
using CallingPoint = RailDataEngine.Domain.Entity.StationBoard.CallingPoint;
using ServiceDetails = RailDataEngine.Domain.Entity.StationBoard.ServiceDetails;

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
                    ServiceId = trainService.serviceID
                });
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
                Departures = new List<Departure>()
            };

            foreach (var trainService in serviceResponse.GetStationBoardResult.trainServices)
            {
                response.Departures.Add(new Departure
                {
                    Operator = trainService.@operator,
                    Origin = trainService.origin[0].locationName,
                    Destination = trainService.destination[0].locationName,
                    ScheduledDeparture = trainService.std,
                    EstimatedDepature = trainService.etd,
                    Platform = trainService.platform,
                    ServiceId = trainService.serviceID
                });
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
                    GeneratedAt = serviceResponse.GetServiceDetailsResult.generatedAt,
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
