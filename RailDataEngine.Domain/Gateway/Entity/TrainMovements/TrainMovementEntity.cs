using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Gateway.Entity.TrainMovements
{
    public class TrainMovementEntity : TrainMovement, IIdentifyable
    {
        public int Id { get; set; }
    }
}
