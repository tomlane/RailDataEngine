using RailDataEngine.Domain.Entity.TrainDescriber.Berth;
using RailDataEngine.Domain.Entity.TrainDescriber.Signal;

namespace RailDataEngine.Domain.Gateway.TrainDescriber
{
    public interface ITrainDescriberGatewayContainer
    {
        ITrainDescriberStorageGateway<BerthMessage> BerthGateway { get; set; }
        ITrainDescriberStorageGateway<SignalMessage> SignalGateway { get; set; }
    }
}
