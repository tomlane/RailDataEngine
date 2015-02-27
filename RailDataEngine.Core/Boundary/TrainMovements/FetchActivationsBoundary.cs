using System;
using RailDataEngine.Domain.Boundary.TrainMovements.FetchActivationsBoundary;
using RailDataEngine.Domain.Interactor.FetchActivationsInteractor;

namespace RailDataEngine.Core.Boundary.TrainMovements
{
    public class FetchActivationsBoundary : IFetchActivationsBoundary
    {
        private readonly IFetchActivationsInteractor _interactor;

        public FetchActivationsBoundary(IFetchActivationsInteractor interactor)
        {
            if (interactor == null)
                throw new ArgumentNullException("interactor");

            _interactor = interactor;
        }

        public FetchActivationsBoundaryResponse Invoke(FetchActivationsBoundaryRequest request)
        {
            var result = _interactor.FetchActivations(new FetchActivationsInteractorRequest
            {
                Date = request.Date
            });

            return new FetchActivationsBoundaryResponse
            {
                Activations = result.Activations
            };
        }
    }
}
