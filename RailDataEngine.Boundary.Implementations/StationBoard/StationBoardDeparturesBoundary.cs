using System;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardDeparturesBoundary;
using RailDataEngine.Domain.Interactor.StationBoardInteractor;

namespace RailDataEngine.Boundary.Implementations.StationBoard
{
    public class StationBoardDeparturesBoundary : IStationBoardDeparturesBoundary
    {
        private readonly IStationBoardInteractor _interactor;

        public StationBoardDeparturesBoundary(IStationBoardInteractor interactor)
        {
            if (interactor == null) throw new ArgumentNullException("interactor");
            _interactor = interactor;
        }

        public StationBoardDeparturesBoundaryResponse Invoke(StationBoardDeparturesBoundaryRequest request)
        {
            var departures = _interactor.GetDepartures(new StationBoardDeparturesInteractorRequest
            {
                Crs = request.Crs
            });

            return new StationBoardDeparturesBoundaryResponse
            {
                Services = departures.Services,
                StationName = departures.StationName
            };
        }
    }
}
