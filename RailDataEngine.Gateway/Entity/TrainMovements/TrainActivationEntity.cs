using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Gateway.Domain;

namespace RailDataEngine.Gateway.Entity.TrainMovements
{
    public class TrainActivationEntity : TrainActivation, IIdentifyable
    {
        public int Id { get; set; }
    }
}
