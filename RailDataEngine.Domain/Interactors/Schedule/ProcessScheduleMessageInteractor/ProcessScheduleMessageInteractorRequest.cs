using System.Collections.Generic;

namespace RailDataEngine.Domain.Interactors.Schedule.ProcessScheduleMessageInteractor
{
    public class ProcessScheduleMessageInteractorRequest
    {
        public List<string> MessagesToSave { get; set; }
    }
}