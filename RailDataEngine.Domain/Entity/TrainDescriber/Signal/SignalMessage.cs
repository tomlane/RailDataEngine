using System;

namespace RailDataEngine.Domain.Entity.TrainDescriber.Signal
{
    public class SignalMessage
    {
        public DateTime TimeStamp { get; set; }
        public string AreaId { get; set; }
        public SignalMessageType MessageType { get; set; }
        public string Address { get; set; }
        public string Data { get; set; }
        public DateTime ReportTime { get; set; }
    }
}
