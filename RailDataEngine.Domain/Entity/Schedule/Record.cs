using System;
using System.Collections.Generic;
using System.Linq;

namespace RailDataEngine.Domain.Entity.Schedule
{
    public class Record
    {
        public string TrainUid { get; set; }
        public TransactionType? TransactionType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Dictionary<Days, bool> RunningDays { get; set; }
        public string BankHolidayRunning { get; set; }
        public string TrainStatus { get; set; }
        public string TrainCategory { get; set; }
        public string SignallingId { get; set; }
        public string TrainServiceCode { get; set; }
        public string BusinessSector { get; set; }
        public string PowerType { get; set; }
        public string TimingLoad { get; set; }
        public int? Speed { get; set; }
        public string OperatingCharacteristics { get; set; }
        public TrainClass? TrainClass { get; set; }
        public Sleepers? Sleepers { get; set; }
        public Reservations? Reservations { get; set; }
        public string CateringCode { get; set; }
        public ServiceBrand? ServiceBrand { get; set; }
        public StpIndicator? StpIndicator { get; set; }
        public string UicCode { get; set; }
        public string AtocCode { get; set; }
        public bool? IsPerformanceMonitoringApplicable { get; set; }
    }
}
