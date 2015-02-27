using System.Collections.Generic;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Boundary.TrainMovements.FetchCancellationsBoundary
{
    public class FetchCancellationsBoundaryResponse
    {
        public List<TrainCancellation> Cancellations { get; set; }
    }
}