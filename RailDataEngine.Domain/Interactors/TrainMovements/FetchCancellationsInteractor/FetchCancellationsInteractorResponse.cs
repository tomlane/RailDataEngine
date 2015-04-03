using System.Collections.Generic;
using RailDataEngine.Domain.Entities.TrainMovements;

namespace RailDataEngine.Domain.Interactors.TrainMovements.FetchCancellationsInteractor
{
    public class FetchCancellationsInteractorResponse
    {
        public List<TrainCancellation> Cancellations { get; set; }
    }
}