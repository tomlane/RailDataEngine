using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Gateway.TrainMovements;
using RailDataEngine.Domain.Interactor.FetchServiceMovementsInteractor;

namespace RailDataEngine.Core.Interactor.TrainMovements
{
    public class FetchServiceMovementsInteractor : IFetchServiceMovementsInteractor
    {
        private ITrainMovementGatewayContainer _gatewayContainer;

        public FetchServiceMovementsInteractor(ITrainMovementGatewayContainer gatewayContainer)
        {
            if (gatewayContainer == null)
                throw new ArgumentNullException("gatewayContainer");

            _gatewayContainer = gatewayContainer;
        }

        public FetchServiceMovementsInteractorResponse FetchServiceMovements(FetchServiceMovementsInteractorRequest request)
        {
            if (request.Date == null)
                request.Date = DateTime.UtcNow;

            Task<TrainActivation> fetchActivationTask =
                Task<TrainActivation>.Factory.StartNew(() => FetchActivation(request));
            Task<TrainCancellation> fetchCancellationTask =
                Task<TrainCancellation>.Factory.StartNew(() => FetchCancellation(request));
            Task<List<TrainMovement>> fetchMovementsTask =
                Task<List<TrainMovement>>.Factory.StartNew(() => FetchMovements(request));
            
            Task[] tasks =
            {
                fetchActivationTask,
                fetchCancellationTask,
                fetchMovementsTask
            };

            Task.WaitAll(tasks);

            return new FetchServiceMovementsInteractorResponse
            {
                Activation = fetchActivationTask.Result,
                Cancellation = fetchCancellationTask.Result,
                Movements = fetchMovementsTask.Result
            };
        }

        private List<TrainMovement> FetchMovements(FetchServiceMovementsInteractorRequest request)
        {
            return _gatewayContainer.MovementGateway.Read(
                x => x.PlannedTimestamp.Value.Day == request.Date.Value.Day && x.TrainId == request.TrainId);
        }

        private TrainCancellation FetchCancellation(FetchServiceMovementsInteractorRequest request)
        {
            var cancellation = _gatewayContainer.CancellationGateway.Read(x => x.TrainId == request.TrainId && x.Timestamp.Value.Day == request.Date.Value.Day);

            if (!cancellation.Any())
                return null;

            return cancellation.First();
        }

        private TrainActivation FetchActivation(FetchServiceMovementsInteractorRequest request)
        {
            var activation = _gatewayContainer.ActivationGateway.Read(x => x.TrainId == request.TrainId);

            if (!activation.Any())
                return null;

            return activation.First();
        }
    }
}
