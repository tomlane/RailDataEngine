using System;

namespace RailDataEngine.Domain.Boundaries.Schedule.FetchServiceScheduleBoundary
{
    public class FetchServiceScheduleBoundaryRequest
    {
        public string TrainUid { get; set; }
        public DateTime? Date { get; set; }
    }
}