using System;
using System.Collections.Generic;

namespace RailDataEngine.Domain.Entity.Schedule
{
    public class Association
    {
        public TransactionType? TransactionType { get; set; }
        public string MainTrainUid { get; set; }
        public string TrainUid { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Dictionary<Days, bool> Days { get; set; }
        public Category? Category { get; set; }
        public DateIndicator? DateIndicator { get; set; }
        public string Location { get; set; }
        public string BaseLocationSuffix { get; set; }
        public string LocationSuffix { get; set; }
        public StpIndicator? StpIndicator { get; set; }
    }
}
