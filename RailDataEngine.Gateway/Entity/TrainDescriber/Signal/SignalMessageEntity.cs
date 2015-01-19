using RailDataEngine.Domain.Entity.TrainDescriber.Signal;
using RailDataEngine.Gateway.Domain;

namespace RailDataEngine.Gateway.Entity.TrainDescriber.Signal
{
    public class SignalMessageEntity : SignalMessage, IIdentifyable
    {
        public int Id { get; set; }
    }
}
