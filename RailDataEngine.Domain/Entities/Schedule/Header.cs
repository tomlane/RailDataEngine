using System;

namespace RailDataEngine.Domain.Entities.Schedule
{
    public class Header : ScheduleEntity
    {
        public string Classification { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Owner { get; set; }
        public Sender Sender { get; set; }
        public MetaData MetaData { get; set; }
    }

    public class MetaData
    {
        public string Type { get; set; }
        public string Sequence { get; set; }
    }

    public class Sender
    {
        public string Organisation { get; set; }
        public string Application { get; set; }
        public string Component { get; set; }
    }
}
