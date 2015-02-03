using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Gateway.Entity.TrainMovements
{
    public class TrainCancellationEntity : TrainCancellation, IIdentifyable
    {
        public int Id { get; set; }
    }
}
