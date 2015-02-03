using System.Collections.Generic;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Boundary.TrainMovements.FetchMovementMessageBoundary
{
    public class FetchMovementMessagesBoundaryResponse
    {
        public TrainActivation Activation { get; set; }
        public TrainCancellation Cancellation { get; set; }
        public List<TrainMovement> Movements { get; set; }
    }
}