using System.Collections.Generic;

namespace RailDataEngine.Domain.Interactor.SaveScheduleMessageInteractor
{
    public class SaveScheduleMessageInteractorRequest
    {
        public List<string> MessagesToSave { get; set; }
    }
}