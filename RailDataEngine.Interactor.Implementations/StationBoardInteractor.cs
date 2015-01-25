using System;
using System.Collections.Generic;
using RailDataEngine.Domain.Entity.StationBoard;
using RailDataEngine.Interactor.StationBoardInteractor;
using RailDataEngine.Services.StationBoardService;

namespace RailDataEngine.Interactor.Implementations
{
    public class StationBoardInteractor : IStationBoardInteractor
    {
        private IStationBoardService _stationBoardService;

        public StationBoardInteractor(IStationBoardService stationBoardService)
        {
            if (stationBoardService == null) throw new ArgumentNullException("stationBoardService");
            _stationBoardService = stationBoardService;
        }

        public List<Arrival> GetArrivals(StationBoardArrivalsInteractorRequest request)
        {
            var arrivals = _stationBoardService.GetArrivals(new StationBoardRequest
            {
                Crs = request.Crs
            });

            return null;
        }

        public List<Departure> GetDepartures(StationBoardDeparturesInteractorRequest request)
        {
            var departures = _stationBoardService.GetDepartures(new StationBoardRequest
            {
                Crs = request.Crs
            });

            return null;
        }

        public ServiceDetails GetServiceDetails(StationBoardServiceDetailsInteractorRequest request)
        {
            var serviceDetails = _stationBoardService.GetServiceDetails(new ServiceDetailsRequest
            {
                ServiceId = request.ServiceId
            });

            return null;
        }
    }
}
