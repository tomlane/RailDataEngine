using RailDataEngine.Domain.Gateway.Entity.TrainDescriber.Berth;
using RailDataEngine.Domain.Gateway.Entity.TrainDescriber.Signal;

namespace RailDataEngine.Domain.Gateway
{
    public interface ITrainDescriberContainer
    {
        IStorageGateway<BerthMessageEntity> BerthGateway { get; set; }
        IStorageGateway<SignalMessageEntity> SignalGateway { get; set; }
    }
}
