﻿using System;
using RailDataEngine.Domain.Gateway;
using RailDataEngine.Domain.Gateway.Entity.TrainDescriber.Berth;
using RailDataEngine.Domain.Gateway.Entity.TrainDescriber.Signal;

namespace RailDataEngine.Gateway.EF.Containers
{
    public class TrainDescriberGatewayContainer : ITrainDescriberContainer
    {
        public IStorageGateway<BerthMessageEntity> BerthGateway { get; set; }
        public IStorageGateway<SignalMessageEntity> SignalGateway { get; set; }

        public TrainDescriberGatewayContainer(
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
