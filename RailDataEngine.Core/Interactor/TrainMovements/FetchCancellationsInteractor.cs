using System;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Gateway.TrainMovements;
using RailDataEngine.Domain.Interactor.FetchCancellationsInteractor;

namespace RailDataEngine.Core.Interactor.TrainMovements
{
    public class FetchCancellationsInteractor : IFetchCancellationsInteractor
    {
        private readonly ITrainMovementStorageGateway<TrainCancellation> _gateway;

        public FetchCancellationsInteractor(ITrainMovementStorageGateway<TrainCancellation> gateway)
        {
            if (gateway == null)
                throw new ArgumentNullException("gateway");

            _gateway = gateway;
        }

        public FetchCancellationsInteractorResponse FetchCancellations(FetchCancellationsInteractorRequest request)
        {
            if (request.Date == null)
                request.Date = DateTime.UtcNow;

            return new FetchCancellationsInteractorResponse
            {
                Cancellations = _gateway.Read(x => x.Timestamp == request.Date)
            };
        }
    }
}
