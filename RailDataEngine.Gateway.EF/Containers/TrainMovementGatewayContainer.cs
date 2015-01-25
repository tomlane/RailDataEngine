using System;
using RailDataEngine.Gateway.Domain;
using RailDataEngine.Gateway.Entity.TrainMovements;

namespace RailDataEngine.Gateway.EF.Containers
{
    public class TrainMovementGatewayContainer : ITrainMovementGatewayContainer
    {
        public IStorageGateway<TrainActivationEntity> ActivationGateway { get; set; }
        public IStorageGateway<TrainCancellationEntity> CancellationGateway { get; set; }
        public IStorageGateway<TrainMovementEntity> MovementGateway { get; set; }

        public TrainMovementGatewayContainer(
            IStorageGateway<TrainActivationEntity> activationGateway, 
            IStorageGateway<TrainCancellationEntity> cancellationGateway,
            IStorageGateway<TrainMovementEntity> movementGateway)
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
