using System.Collections.Generic;
using RailDataEngine.Domain.Entities.TrainMovements;

namespace RailDataEngine.Domain.Boundaries.TrainMovements.FetchCancellationsBoundary
{
    public class FetchCancellationsBoundaryResponse
    {
        public List<TrainCancellation> Cancellations { get; set; }
    }
}