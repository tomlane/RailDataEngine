using System;
using RailDataEngine.Domain.Gateway;

namespace RailDataEngine.Domain.Entity.TrainMovements
{
    public class TrainActivation : IIdentifyable
    {
        public int Id { get; set; }
        public string TrainId { get; set; }
        public DateTime? CreationTimestamp { get; set; }
        public DateTime? OriginTimestamp { get; set; }
        public string TrainUid { get; set; }
        public string ScheduleOriginStanox { get; set; }
        public DateTime? ScheduleStartDate { get; set; }
        public DateTime? ScheduleEndDate { get; set; }
        public ScheduleSource? ScheduleSource { get; set; }
        public ScheduleType? ScheduleType { get; set; }
        public string OriginStanox { get; set; }
        public DateTime? OriginDepartureTimestamp { get; set; }
        public TrainCallType? CallType { get; set; }
        public TrainCallMode? CallMode { get; set; }
    }
}
