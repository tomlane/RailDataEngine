using System;
using RailDataEngine.Domain.Interactor.StationBoardInteractor;
using RailDataEngine.Domain.Services.StationBoardService;

namespace RailDataEngine.Core.Interactor.StationBoard
{
    public class StationBoardInteractor : IStationBoardInteractor
    {
        private readonly IStationBoardService _stationBoardService;

        public StationBoardInteractor(IStationBoardService stationBoardService)
        {
            if (stationBoardService == null) throw new ArgumentNullException("stationBoardService");
            _stationBoardService = stationBoardService;
        }

        public StationBoardArrivalsInteractorResponse GetArrivals(StationBoardArrivalsInteractorRequest request)
        {
            var arrivals = _stationBoardService.GetArrivals(new StationBoardRequest
            {
                Crs = request.Crs.ToUpper()
            });

            return new StationBoardArrivalsInteractorResponse
            {
                Services = arrivals.Services,
                StationName = arrivals.StationName
            };
        }

        public StationBoardDeparturesInteractorResponse GetDepartures(StationBoardDeparturesInteractorRequest request)
        {
            var departures = _stationBoardService.GetDepartures(new StationBoardRequest
            {
                Crs = request.Crs.ToUpper()
            });

            return new StationBoardDeparturesInteractorResponse
            {
                Services = departures.Services,
                StationName = departures.StationName
            };
        }

        public StationBoardServiceDetailsInteractorResponse GetServiceDetails(StationBoardServiceDetailsInteractorRequest request)
        {
            var serviceDetails = _stationBoardService.GetServiceDetails(new ServiceDetailsRequest
            {
                ServiceId = request.ServiceId
            });

            return new StationBoardServiceDetailsInteractorResponse
            {
                ServiceDetails = serviceDetails.ServiceDetails
            };
        }
    }
}
