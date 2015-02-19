using System;
using System.Collections.Generic;
using RailDataEngine.Domain.Gateway;

namespace RailDataEngine.Domain.Entity.Schedule
{
    public class Record : IIdentifyable
    {
        public int Id { get; set; }
        public string TrainUid { get; set; }
        public TransactionType? TransactionType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string RunningDays { get; set; }
        public bool BankHolidayRunning { get; set; }
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
        public CateringCode? CateringCode { get; set; }
        public ServiceBrand? ServiceBrand { get; set; }
        public StpIndicator? StpIndicator { get; set; }
        public string UicCode { get; set; }
        public string AtocCode { get; set; }
        public bool? IsPerformanceMonitoringApplicable { get; set; }
        public virtual List<Location> Locations { get; set; }
    }
}
