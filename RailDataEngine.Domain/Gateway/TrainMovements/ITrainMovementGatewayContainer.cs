﻿using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Gateway.TrainMovements
{
    public interface ITrainMovementGatewayContainer
    {
        ITrainMovementStorageGateway<TrainActivation> ActivationGateway { get; set; }
        ITrainMovementStorageGateway<TrainCancellation> CancellationGateway { get; set; }
        ITrainMovementStorageGateway<TrainMovement> MovementGateway { get; set; }
    }
}
