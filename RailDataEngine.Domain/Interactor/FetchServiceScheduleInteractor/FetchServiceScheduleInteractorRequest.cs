using System;

namespace RailDataEngine.Domain.Interactor.FetchServiceScheduleInteractor
{
    public class FetchServiceScheduleInteractorRequest
    {
        public DateTime? Date { get; set; }
        public string TrainUid { get; set; }
    }
}