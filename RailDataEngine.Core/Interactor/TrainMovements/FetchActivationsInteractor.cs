using System;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Gateway.TrainMovements;
using RailDataEngine.Domain.Interactor.FetchActivationsInteractor;

namespace RailDataEngine.Core.Interactor.TrainMovements
{
    public class FetchActivationsInteractor : IFetchActivationsInteractor
    {
        private readonly ITrainMovementStorageGateway<TrainActivation> _gateway;

        public FetchActivationsInteractor(ITrainMovementStorageGateway<TrainActivation> gateway)
        {
            if (gateway == null)
                throw new ArgumentNullException("gateway");

            _gateway = gateway;
        }

        public FetchActivationsInteractorResponse FetchActivations(FetchActivationsInteractorRequest request)
        {
            if (request.Date == null)
                request.Date = DateTime.UtcNow;

            return new FetchActivationsInteractorResponse
            {
                Activations = _gateway.Read(x => x.OriginTimestamp == request.Date)
            };
        }
    }
}
