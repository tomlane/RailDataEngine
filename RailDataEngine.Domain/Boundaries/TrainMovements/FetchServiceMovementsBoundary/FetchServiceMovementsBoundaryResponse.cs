using System.Collections.Generic;
using RailDataEngine.Domain.Entities.TrainMovements;

namespace RailDataEngine.Domain.Boundaries.TrainMovements.FetchServiceMovementsBoundary
{
    public class FetchServiceMovementsBoundaryResponse
    {
        public TrainActivation Activation { get; set; }
        public TrainCancellation Cancellation { get; set; }
        public List<TrainMovement> Movements { get; set; }
    }
}