using System.Collections.Generic;

namespace RailDataEngine.Domain.Services.ScheduleMessageDeserializationService
{
    public class ScheduleMessageDeserializationRequest
    {
        public List<string> MessagesToDeserialize { get; set; }
    }
}