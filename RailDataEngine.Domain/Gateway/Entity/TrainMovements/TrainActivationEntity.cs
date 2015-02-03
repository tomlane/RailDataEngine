using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Gateway.Entity.TrainMovements
{
    public class TrainActivationEntity : TrainActivation, IIdentifyable
    {
        public int Id { get; set; }
    }
}
