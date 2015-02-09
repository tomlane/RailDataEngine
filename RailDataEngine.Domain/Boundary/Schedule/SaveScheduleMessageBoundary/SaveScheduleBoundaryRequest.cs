using System.Collections.Generic;

namespace RailDataEngine.Domain.Boundary.Schedule.SaveScheduleMessageBoundary
{
    public class SaveScheduleBoundaryRequest
    {
        public List<string> MessagesToSave { get; set; }
    }
}