using System.Collections.Generic;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Interactor.TrainMovements.FetchCancellationsInteractor
{
    public class FetchCancellationsInteractorResponse
    {
        public List<TrainCancellation> Cancellations { get; set; }
    }
}