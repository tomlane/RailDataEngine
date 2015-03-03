using System.Collections.Generic;

namespace RailDataEngine.Domain.Interactor.ProcessScheduleMessageInteractor
{
    public class ProcessScheduleMessageInteractorRequest
    {
        public List<string> MessagesToSave { get; set; }
    }
}