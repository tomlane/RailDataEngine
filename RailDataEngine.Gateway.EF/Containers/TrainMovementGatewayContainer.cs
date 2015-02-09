using System;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Gateway;

namespace RailDataEngine.Gateway.EF.Containers
{
    public class TrainMovementGatewayContainer : ITrainMovementGatewayContainer
    {
        public IStorageGateway<TrainActivation> ActivationGateway { get; set; }
        public IStorageGateway<TrainCancellation> CancellationGateway { get; set; }
        public IStorageGateway<TrainMovement> MovementGateway { get; set; }

        public TrainMovementGatewayContainer(
            IStorageGateway<TrainActivation> activationGateway, 
            IStorageGateway<TrainCancellation> cancellationGateway,
            IStorageGateway<TrainMovement> movementGateway)
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
