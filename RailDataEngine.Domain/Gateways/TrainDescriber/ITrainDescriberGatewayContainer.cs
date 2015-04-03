using RailDataEngine.Domain.Entities.TrainDescriber.Berth;
using RailDataEngine.Domain.Entities.TrainDescriber.Signal;

namespace RailDataEngine.Domain.Gateways.TrainDescriber
{
    public interface ITrainDescriberGatewayContainer
    {
        ITrainDescriberStorageGateway<BerthMessage> BerthGateway { get; set; }
        ITrainDescriberStorageGateway<SignalMessage> SignalGateway { get; set; }
    }
}
