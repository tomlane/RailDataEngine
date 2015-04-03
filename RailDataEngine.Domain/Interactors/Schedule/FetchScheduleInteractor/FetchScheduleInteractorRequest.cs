using System;

namespace RailDataEngine.Domain.Interactors.Schedule.FetchScheduleInteractor
{
    public class FetchScheduleInteractorRequest
    {
        public DateTime? Date { get; set; }
        public string TrainUid { get; set; }
    }
}