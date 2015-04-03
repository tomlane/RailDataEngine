using RailDataEngine.Domain.Entities.TrainMovements;

namespace RailDataEngine.Domain.Gateways.TrainMovements
{
    public interface ITrainMovementGatewayContainer
    {
        ITrainMovementStorageGateway<TrainActivation> ActivationGateway { get; set; }
        ITrainMovementStorageGateway<TrainCancellation> CancellationGateway { get; set; }
        ITrainMovementStorageGateway<TrainMovement> MovementGateway { get; set; }
    }
}
