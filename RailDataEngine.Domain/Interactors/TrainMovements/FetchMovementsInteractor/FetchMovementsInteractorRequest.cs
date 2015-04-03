using System;

namespace RailDataEngine.Domain.Interactors.TrainMovements.FetchMovementsInteractor
{
    public class FetchMovementsInteractorRequest
    {
        public string TrainId { get; set; }
        public DateTime? Date { get; set; }
    }
}