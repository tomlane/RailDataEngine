using System.Collections.Generic;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Services.MovementMessageConversionService
{
    public class MovementMessageConversionResponse
    {
        public List<TrainActivation> Activations { get; set; }
        public List<TrainCancellation> Cancellations { get; set; }
        public List<TrainMovement> Movements { get; set; }
    }
}