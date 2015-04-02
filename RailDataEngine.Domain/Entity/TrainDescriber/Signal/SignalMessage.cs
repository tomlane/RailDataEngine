using System;

namespace RailDataEngine.Domain.Entity.TrainDescriber.Signal
{
    public class SignalMessage : TrainDescriberEntity
    {
        public SignalMessageType? MessageType { get; set; }
        public string Address { get; set; }
        public string Data { get; set; }
        public DateTime? ReportTime { get; set; }
    }
}
