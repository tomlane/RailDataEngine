using System.Collections.Generic;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Boundary.TrainMovements.FetchActivationsBoundary
{
    public class FetchActivationsBoundaryResponse
    {
        public List<TrainActivation> Activations { get; set; }
    }
}