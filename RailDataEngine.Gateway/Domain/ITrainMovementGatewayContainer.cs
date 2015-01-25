using RailDataEngine.Gateway.Entity.TrainMovements;

namespace RailDataEngine.Gateway.Domain
{
    public interface ITrainMovementGatewayContainer
    {
        IStorageGateway<TrainActivationEntity> ActivationGateway { get; set; }
        IStorageGateway<TrainCancellationEntity> CancellationGateway { get; set; }
        IStorageGateway<TrainMovementEntity> MovementGateway { get; set; }
    }
}
