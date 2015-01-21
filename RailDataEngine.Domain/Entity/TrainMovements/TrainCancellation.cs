using System;

namespace RailDataEngine.Domain.Entity.TrainMovements
{
    public class TrainCancellation
    {
        public string TrainId { get; set; }
        public string OriginalLocationStanox { get; set; }
        public DateTime? OriginalLocationTimestamp { get; set; }
        public string TocId { get; set; }
        public DateTime? DepartureTimestamp { get; set; }
        public string DivisionCode { get; set; }
        public string LocationStanox { get; set; }
        public DateTime? Timestamp { get; set; }
        public string ReasonCode { get; set; }
        public CancellationType? Type { get; set; }
        public string TrainServiceCode { get; set; }
        public string TrainFileAdress { get; set; }
    }
}
