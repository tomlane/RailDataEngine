using System.Collections.Generic;

namespace RailDataEngine.Domain.Boundary.Schedule.ProcessScheduleMessageBoundary
{
    public class ProcessScheduleBoundaryRequest
    {
        public List<string> MessagesToSave { get; set; }
    }
}