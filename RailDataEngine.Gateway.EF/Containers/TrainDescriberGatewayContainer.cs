using System;
using RailDataEngine.Domain.Entity.TrainDescriber.Berth;
using RailDataEngine.Domain.Entity.TrainDescriber.Signal;
using RailDataEngine.Domain.Gateway;

namespace RailDataEngine.Gateway.EF.Containers
{
    public class TrainDescriberGatewayContainer : ITrainDescriberGatewayContainer
    {
        public ITrainDescriberStorageGateway<BerthMessage> BerthGateway { get; set; }
        public ITrainDescriberStorageGateway<SignalMessage> SignalGateway { get; set; }

        public TrainDescriberGatewayContainer(
            ITrainDescriberStorageGateway<BerthMessage> berthGateway,
            ITrainDescriberStorageGateway<SignalMessage> signalGateway)
        {
            if (berthGateway == null) throw new ArgumentNullException("berthGateway");
            if (signalGateway == null) throw new ArgumentNullException("signalGateway");

            BerthGateway = berthGateway;
            SignalGateway = signalGateway;
        }
    }
}
