using System;
using RailDataEngine.Gateway.Domain;
using RailDataEngine.Gateway.Entity.TrainDescriber.Berth;
using RailDataEngine.Gateway.Entity.TrainDescriber.Signal;

namespace RailDataEngine.Gateway.EF.Containers
{
    public class DescriberGatewayContainer : IDescriberContainer
    {
        public IStorageGateway<BerthMessageEntity> BerthGateway { get; set; }
        public IStorageGateway<SignalMessageEntity> SignalGateway { get; set; }

        public DescriberGatewayContainer(
            IStorageGateway<BerthMessageEntity> berthGateway,
            IStorageGateway<SignalMessageEntity> signalGateway)
        {
            if (berthGateway == null) throw new ArgumentNullException("berthGateway");
            if (signalGateway == null) throw new ArgumentNullException("signalGateway");

            BerthGateway = berthGateway;
            SignalGateway = signalGateway;
        }
    }
}
