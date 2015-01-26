using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using RailDataEngine.Domain.Entity.StationBoard;
using RailDataEngine.Services.DarwinStationBoard.DarwinServiceReference;
using RailDataEngine.Services.Exception;
using RailDataEngine.Services.StationBoardService;

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
                throw new NullServiceResultException("Darwin SOAP service", string.Format("Arrivals for {0}", request.Crs));

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
            throw new System.NotImplementedException();
        }

        public ServiceDetailsResponse GetServiceDetails(ServiceDetailsRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
