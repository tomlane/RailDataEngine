using System.Collections.Generic;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Services.MovementMessageStorageService
{
    public class SaveMovementMessagesRequest
    {
        public List<TrainActivation> Activations { get; set; }
        public List<TrainCancellation> Cancellations { get; set; }
        public List<TrainMovement> Movements { get; set; }
    }
}
