using System;

namespace RailDataEngine.Domain.Interactors.TrainMovements.FetchCancellationsInteractor
{
    public class FetchCancellationsInteractorRequest
    {
        public DateTime? Date { get; set; }
    }
}