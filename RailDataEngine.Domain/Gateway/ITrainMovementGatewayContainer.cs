using RailDataEngine.Domain.Gateway.Entity.TrainMovements;

namespace RailDataEngine.Domain.Gateway
{
    public interface ITrainMovementGatewayContainer
    {
        IStorageGateway<TrainActivationEntity> ActivationGateway { get; set; }
        IStorageGateway<TrainCancellationEntity> CancellationGateway { get; set; }
        IStorageGateway<TrainMovementEntity> MovementGateway { get; set; }
    }
}
