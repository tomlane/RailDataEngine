using System;
using System.Linq;
using RailDataEngine.Domain.Gateway.TrainMovements;
using RailDataEngine.Domain.Services.MovementMessageStorageService;

namespace RailDataEngine.Services.MessageStorage
{
    public class MovementMessageStorageService : IMovementMessageStorageService
    {
        private ITrainMovementGatewayContainer _gatewayContainer;

        public MovementMessageStorageService(ITrainMovementGatewayContainer gatewayContainer)
        {
            if (gatewayContainer == null)
                throw new ArgumentNullException("gatewayContainer");

            _gatewayContainer = gatewayContainer;
        }

        public void SaveMovementMessages(SaveMovementMessagesRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (request.Activations != null && request.Activations.Any())
                _gatewayContainer.ActivationGateway.Create(request.Activations);

            if (request.Cancellations != null && request.Cancellations.Any())
                _gatewayContainer.CancellationGateway.Create(request.Cancellations);

            if (request.Movements != null && request.Movements.Any())
                _gatewayContainer.MovementGateway.Create(request.Movements);
        }
    }
}
