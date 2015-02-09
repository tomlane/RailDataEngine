using System;
using RailDataEngine.Domain.Gateway;

namespace RailDataEngine.Domain.Entity.TrainDescriber.Signal
{
    public class SignalMessage : IIdentifyable
    {
        public int Id { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string AreaId { get; set; }
        public SignalMessageType? MessageType { get; set; }
        public string Address { get; set; }
        public string Data { get; set; }
        public DateTime? ReportTime { get; set; }
    }
}
