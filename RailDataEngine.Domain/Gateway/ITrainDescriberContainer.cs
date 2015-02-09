using RailDataEngine.Domain.Entity.TrainDescriber.Berth;
using RailDataEngine.Domain.Entity.TrainDescriber.Signal;

namespace RailDataEngine.Domain.Gateway
{
    public interface ITrainDescriberContainer
    {
        IStorageGateway<BerthMessage> BerthGateway { get; set; }
        IStorageGateway<SignalMessage> SignalGateway { get; set; }
    }
}
