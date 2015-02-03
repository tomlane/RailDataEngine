using System;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardServiceDetailsBoundary;
using RailDataEngine.Domain.Interactor.StationBoardInteractor;

namespace RailDataEngine.Boundary.Implementations.StationBoard
{
    public class StationBoardServiceDetailsBoundary : IStationBoardServiceDetailsBoundary
    {
        private readonly IStationBoardInteractor _interactor;

        public StationBoardServiceDetailsBoundary(IStationBoardInteractor interactor)
        {
            if (interactor == null) throw new ArgumentNullException("interactor");
            _interactor = interactor;
        }

        public StationBoardServiceDetailsBoundaryResponse Invoke(StationBoardServiceDetailsBoundaryRequest request)
        {
            var serviceDetails = _interactor.GetServiceDetails(new StationBoardServiceDetailsInteractorRequest
            {
                ServiceId = request.ServiceId
            });

            return new StationBoardServiceDetailsBoundaryResponse
            {
                ServiceDetails = serviceDetails.ServiceDetails
            };
        }
    }
}
