using System;

namespace RailDataEngine.Domain.Boundary.Schedule.FetchServiceScheduleBoundary
{
    public class FetchServiceScheduleBoundaryRequest
    {
        public string TrainUid { get; set; }
        public DateTime? Date { get; set; }
    }
}