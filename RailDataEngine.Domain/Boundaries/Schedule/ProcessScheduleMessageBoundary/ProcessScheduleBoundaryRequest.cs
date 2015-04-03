using System.Collections.Generic;

namespace RailDataEngine.Domain.Boundaries.Schedule.ProcessScheduleMessageBoundary
{
    public class ProcessScheduleBoundaryRequest
    {
        public List<string> MessagesToSave { get; set; }
    }
}