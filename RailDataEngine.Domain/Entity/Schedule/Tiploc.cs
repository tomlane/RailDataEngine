using RailDataEngine.Domain.Entity.Schedule.Enums;

namespace RailDataEngine.Domain.Entity.Schedule
{
    public class Tiploc : ScheduleEntity
    {
        public TransactionType? TransactionType { get; set; }
        public string TiplocCode { get; set; }
        public string Nalco { get; set; }
        public string Stanox { get; set; }
        public string CrsCode { get; set; }
        public string Description { get; set; }
        public string TpsDescription { get; set; }
    }
}
