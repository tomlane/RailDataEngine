using System;

namespace RailDataEngine.Domain.Entity.TrainMovements
{
    public class TrainMovement
    {
        public string TrainId { get; set; }
        public DateTime ActualTimestamp { get; set; }
        public string LocationStanox { get; set; }
        public DateTime PassengerTimestamp { get; set; }
        public DateTime PlannedTimestamp { get; set; }
        public string OriginalLocationStanox { get; set; }
        public DateTime OriginalLocationTimestamp { get; set; }
        public EventType PlannedEventType { get; set; }
        public EventType EventType { get; set; }
        public EventSource EventSource { get; set; }
        public bool IsCorrection { get; set; }
        public bool IsOffRoute { get; set; }
        public Direction Direction { get; set; }
        public string Line { get; set; }
        public string Route { get; set; }
        public string CurrentTrainId { get; set; }
        public string TrainServiceCode { get; set; }
        public string DivisionCode { get; set; }
        public string TocId { get; set; }
        public int TimetableVariation { get; set; }
        public VariationStatus VariationStatus { get; set; }
        public string NextReportStanox { get; set; }
        public int NextReportRunTime { get; set; }
        public bool HasTerminated { get; set; }
        public bool IsDelayMonitoringPoint { get; set; }
        public string TrainFileAddress { get; set; }
        public string ReportingStanox { get; set; }
        public bool IsAutoExpected { get; set; }
    }
}
