using System.Collections.Generic;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService.Entity;

namespace RailDataEngine.Domain.Services.MovementMessageDeserializationService
{
    public class MovementMessageDeserializationResponse
    {
        public List<DeserializedJsonTrainActivation> Activations { get; set; }
        public List<DeserializedJsonTrainCancellation> Cancellations { get; set; }
        public List<DeserializedJsonTrainMovement> Movements { get; set; }
    }
}