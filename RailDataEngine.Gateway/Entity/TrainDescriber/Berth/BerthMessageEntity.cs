using RailDataEngine.Domain.Entity.TrainDescriber.Berth;
using RailDataEngine.Gateway.Domain;

namespace RailDataEngine.Gateway.Entity.TrainDescriber.Berth
{
    public class BerthMessageEntity : BerthMessage, IIdentifyable
    {
        public int Id { get; set; }
    }
}
