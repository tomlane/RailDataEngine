using System;
using RailDataEngine.Domain.Gateway;

namespace RailDataEngine.Domain.Entity.Schedule
{
    public class Association : IIdentifyable
    {
        public int Id { get; set; }
        public TransactionType? TransactionType { get; set; }
        public string MainTrainUid { get; set; }
        public string TrainUid { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Days { get; set; }
        public Category? Category { get; set; }
        public DateIndicator? DateIndicator { get; set; }
        public string Location { get; set; }
        public string BaseLocationSuffix { get; set; }
        public string LocationSuffix { get; set; }
        public StpIndicator? StpIndicator { get; set; }
    }
}
