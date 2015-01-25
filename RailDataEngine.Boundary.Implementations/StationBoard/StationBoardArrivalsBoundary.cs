using System;
using RailDataEngine.Boundary.StationBoard.StationBoardArrivalsBoundary;
using RailDataEngine.Interactor.StationBoardInteractor;

namespace RailDataEngine.Boundary.Implementations.StationBoard
{
    public class StationBoardArrivalsBoundary : IStationBoardArrivalsBoundary
    {
        private readonly IStationBoardInteractor _interactor;

        public StationBoardArrivalsBoundary(IStationBoardInteractor interactor)
        {
            if (interactor == null) throw new ArgumentNullException("interactor");
            _interactor = interactor;
        }

        public StationBoardArrivalsBoundaryResponse Invoke(StationBoardArrivalsBoundaryRequest request)
        {
            return new StationBoardArrivalsBoundaryResponse
            {
                Arrivals = _interactor.GetArrivals(new StationBoardArrivalsInteractorRequest
                {
                    Crs = request.Crs
                })
            };
        }
    }
}
