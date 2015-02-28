using System;

namespace RailDataEngine.Domain.Interactor.FetchServiceMovementsInteractor
{
    public class FetchServiceMovementsInteractorRequest
    {
        public string TrainId { get; set; }
        public DateTime? Date { get; set; }
    }
}