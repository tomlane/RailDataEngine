using RailDataEngine.Gateway.Entity.TrainDescriber.Berth;
using RailDataEngine.Gateway.Entity.TrainDescriber.Signal;

namespace RailDataEngine.Gateway.Domain
{
    public interface IDescriberContainer
    {
        IStorageGateway<BerthMessageEntity> BerthGateway { get; set; }
        IStorageGateway<SignalMessageEntity> SignalGateway { get; set; }
    }
}
