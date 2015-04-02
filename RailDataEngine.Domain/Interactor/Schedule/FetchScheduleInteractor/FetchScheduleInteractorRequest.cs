using System;

namespace RailDataEngine.Domain.Interactor.Schedule.FetchScheduleInteractor
{
    public class FetchScheduleInteractorRequest
    {
        public DateTime? Date { get; set; }
        public string TrainUid { get; set; }
    }
}