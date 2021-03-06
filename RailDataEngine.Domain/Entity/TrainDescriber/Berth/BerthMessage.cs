﻿using System;
using RailDataEngine.Domain.Gateway;

namespace RailDataEngine.Domain.Entity.TrainDescriber.Berth
{
    public class BerthMessage : IIdentifyable
    {
        public int Id { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string AreaId { get; set; }
        public BerthMessageType? MessageType { get; set; }
        public string FromBerth { get; set; }
        public string ToBerth { get; set; }
        public string TrainDescription { get; set; }
    }
}
