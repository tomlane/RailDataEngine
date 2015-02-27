using System;
using RailDataEngine.Domain.Boundary.TrainMovements.FetchCancellationsBoundary;
using RailDataEngine.Domain.Interactor.FetchCancellationsInteractor;

namespace RailDataEngine.Core.Boundary.TrainMovements
{
    public class FetchCancellationsBoundary : IFetchCancellationsBoundary
    {
        private readonly IFetchCancellationsInteractor _interactor;

        public FetchCancellationsBoundary(IFetchCancellationsInteractor interactor)
        {
            if (interactor == null)
                throw new ArgumentNullException("interactor");

            _interactor = interactor;
        }

        public FetchCancellationsBoundaryResponse Invoke(FetchCancellationsBoundaryRequest request)
        {
            var result = _interactor.FetchCancellations(new FetchCancellationsInteractorRequest
            {
                Date = request.Date
            });

            return new FetchCancellationsBoundaryResponse
            {
                Cancellations = result.Cancellations
            };
        }
    }
}
