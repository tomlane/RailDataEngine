using System.Collections.Generic;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Interactor.FetchCancellationsInteractor
{
    public class FetchCancellationsInteractorResponse
    {
        public List<TrainCancellation> Cancellations { get; set; }
    }
}