using System;
using System.Collections.Generic;
using RailDataEngine.Domain.Entity.StationBoard;
using RailDataEngine.Interactor.StationBoardInteractor;
using RailDataEngine.Services.StationBoardService;

namespace RailDataEngine.Interactor.Implementations
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
                Crs = request.Crs
            });

            return new StationBoardArrivalsInteractorResponse
            {
                Arrivals = arrivals.Services,
                StationName = arrivals.StationName
            };
        }

        public StationBoardDeparturesInteractorResponse GetDepartures(StationBoardDeparturesInteractorRequest request)
        {
            var departures = _stationBoardService.GetDepartures(new StationBoardRequest
            {
                Crs = request.Crs
            });

            return new StationBoardDeparturesInteractorResponse
            {
                Services = departures.Departures,
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
