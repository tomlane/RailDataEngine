using System.Collections.Generic;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Api.Models
{
    public class ServiceMovementResponseModel
    {
        public TrainActivation Activation { get; set; }
        public TrainCancellation Cancellation { get; set; }
        public List<TrainMovement> Movements { get; set; }
    }
}