using RailDataEngine.Domain.Entity.TrainDescriber.Signal;

namespace RailDataEngine.Domain.Gateway.Entity.TrainDescriber.Signal
{
    public class SignalMessageEntity : SignalMessage, IIdentifyable
    {
        public int Id { get; set; }
    }
}
