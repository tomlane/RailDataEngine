using System.Collections.Generic;
using RailDataEngine.Domain.Entity.Schedule;

namespace RailDataEngine.Domain.Boundary.Schedule.FetchScheduleMessageBoundary
{
    public class FetchScheduleMessageBoundaryResponse
    {
        public List<Record> Records { get; set; }
    }
}