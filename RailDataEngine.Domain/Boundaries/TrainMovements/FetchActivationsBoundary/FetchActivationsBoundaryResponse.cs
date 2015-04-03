using System.Collections.Generic;
using RailDataEngine.Domain.Entities.TrainMovements;

namespace RailDataEngine.Domain.Boundaries.TrainMovements.FetchActivationsBoundary
{
    public class FetchActivationsBoundaryResponse
    {
        public List<TrainActivation> Activations { get; set; }
    }
}