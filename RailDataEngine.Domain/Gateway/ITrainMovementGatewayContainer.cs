using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Gateway
{
    public interface ITrainMovementGatewayContainer
    {
        IStorageGateway<TrainActivation> ActivationGateway { get; set; }
        IStorageGateway<TrainCancellation> CancellationGateway { get; set; }
        IStorageGateway<TrainMovement> MovementGateway { get; set; }
    }
}
