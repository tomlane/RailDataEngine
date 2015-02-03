using RailDataEngine.Domain.Entity.TrainDescriber.Berth;

namespace RailDataEngine.Domain.Gateway.Entity.TrainDescriber.Berth
{
    public class BerthMessageEntity : BerthMessage, IIdentifyable
    {
        public int Id { get; set; }
    }
}
