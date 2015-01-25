using System;
using RailDataEngine.Boundary.StationBoard.StationBoardServiceDetailsBoundary;
using RailDataEngine.Interactor.StationBoardInteractor;

namespace RailDataEngine.Boundary.Implementations.StationBoard
{
    public class StationBoardServiceDetailsBoundary : IStationBoardServiceDetailsBoundary
    {
        private IStationBoardInteractor _interactor;

        public StationBoardServiceDetailsBoundary(IStationBoardInteractor interactor)
        {
            if (interactor == null) throw new ArgumentNullException("interactor");
            _interactor = interactor;
        }

        public StationBoardServiceDetailsBoundaryResponse Invoke(StationBoardServiceDetailsBoundaryRequest request)
        {
            return new StationBoardServiceDetailsBoundaryResponse
            {
                ServiceDetails = _interactor.GetServiceDetails(new StationBoardServiceDetailsInteractorRequest
                {
                    ServiceId = request.ServiceId
                })
            };
        }
    }
}
