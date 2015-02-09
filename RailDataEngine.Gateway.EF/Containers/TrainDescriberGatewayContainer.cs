using System;
using RailDataEngine.Domain.Entity.TrainDescriber.Berth;
using RailDataEngine.Domain.Entity.TrainDescriber.Signal;
using RailDataEngine.Domain.Gateway;

namespace RailDataEngine.Gateway.EF.Containers
{
    public class TrainDescriberGatewayContainer : ITrainDescriberContainer
    {
        public IStorageGateway<BerthMessage> BerthGateway { get; set; }
        public IStorageGateway<SignalMessage> SignalGateway { get; set; }

        public TrainDescriberGatewayContainer(
            IStorageGateway<BerthMessage> berthGateway,
            IStorageGateway<SignalMessage> signalGateway)
        {
            if (berthGateway == null) throw new ArgumentNullException("berthGateway");
            if (signalGateway == null) throw new ArgumentNullException("signalGateway");

            BerthGateway = berthGateway;
            SignalGateway = signalGateway;
        }
    }
}
