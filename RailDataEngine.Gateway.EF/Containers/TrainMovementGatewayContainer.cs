using System;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Gateway;
using RailDataEngine.Domain.Gateway.TrainMovements;

namespace RailDataEngine.Gateway.EF.Containers
{
    public class TrainMovementGatewayContainer : ITrainMovementGatewayContainer
    {
        public ITrainMovementStorageGateway<TrainActivation> ActivationGateway { get; set; }
        public ITrainMovementStorageGateway<TrainCancellation> CancellationGateway { get; set; }
        public ITrainMovementStorageGateway<TrainMovement> MovementGateway { get; set; }

        public TrainMovementGatewayContainer(
            ITrainMovementStorageGateway<TrainActivation> activationGateway, 
            ITrainMovementStorageGateway<TrainCancellation> cancellationGateway,
            ITrainMovementStorageGateway<TrainMovement> movementGateway)
        {
            if (activationGateway == null) throw new ArgumentNullException("activationGateway");
            if (cancellationGateway == null) throw new ArgumentNullException("cancellationGateway");
            if (movementGateway == null) throw new ArgumentNullException("movementGateway");

            ActivationGateway = activationGateway;
            CancellationGateway = cancellationGateway;
            MovementGateway = movementGateway;
        }
    }
}
