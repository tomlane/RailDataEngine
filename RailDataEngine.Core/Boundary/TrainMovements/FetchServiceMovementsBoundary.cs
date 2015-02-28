using System;
using RailDataEngine.Domain.Boundary.TrainMovements.FetchServiceMovementsBoundary;
using RailDataEngine.Domain.Interactor.FetchServiceMovementsInteractor;

namespace RailDataEngine.Core.Boundary.TrainMovements
{
    public class FetchServiceMovementsBoundary : IFetchServiceMovementsBoundary
    {
        private readonly IFetchServiceMovementsInteractor _interactor;

        public FetchServiceMovementsBoundary(IFetchServiceMovementsInteractor interactor)
        {
            if (interactor == null)
                throw new ArgumentNullException("interactor");

            _interactor = interactor;
        }

        public FetchServiceMovementsBoundaryResponse Invoke(FetchServiceMovementsBoundaryRequest request)
        {
            var result = _interactor.FetchServiceMovements(new FetchServiceMovementsInteractorRequest
            {
                Date = request.Date,
                TrainId = request.TrainId
            });

            return new FetchServiceMovementsBoundaryResponse
            {
                Activation = result.Activation,
                Cancellation = result.Cancellation,
                Movements = result.Movements
            };
        }
    }
}
