using System;
using System.Collections.Generic;
using RailDataEngine.Domain.Entity.StationBoard;

namespace RailDataEngine.Services.StationBoardService
{
    public class ServiceDetailsResponse
    {
        public DateTime GeneratedAt { get; set; }
        public string Crs { get; set; }
        public bool Cancelled { get; set; }
        public string DisruptionReason { get; set; }
        public string OverdueMessage { get; set; }
        public string LocationName { get; set; }
        public string Operator { get; set; }
        public string Platform { get; set; }
        public string ActualArrivalTime { get; set; }
        public string ActualDepartureTime { get; set; }
        public string EstimatedArrivalTime { get; set; }
        public string EstimatedDepartureTime { get; set; }
        public string ScheduledArrivalTime { get; set; }
        public string ScheduledDepartureTime { get; set; }
        public List<CallingPoint> CallingPoints { get; set; }
        public List<CallingPoint> PreviousCallingPoints { get; set; }
    }
}