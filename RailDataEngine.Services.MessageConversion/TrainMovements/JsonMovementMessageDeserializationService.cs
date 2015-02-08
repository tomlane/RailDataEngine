using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService.Entity;

namespace RailDataEngine.Services.MessageConversion.TrainMovements
{
    public class JsonMovementMessageDeserializationService : IMovementMessageDeserializationService
    {
        public MovementMessageDeserializationResponse DeserializeMovementMessages(MovementMessageDeserializationRequest request)
        {
            if (request == null || request.MessageToDeserialize == null)
                throw new ArgumentNullException("request");

            var response = new MovementMessageDeserializationResponse
            {
                Activations = new List<DeserializedJsonTrainActivation>(),
                Cancellations = new List<DeserializedJsonTrainCancellation>(),
                Movements = new List<DeserializedJsonTrainMovement>()
            };

            JArray jsonArray = JArray.Parse(request.MessageToDeserialize);

            foreach (JObject jObject in jsonArray.Children())
            {
                string messageType = jObject["header"]["msg_type"].ToString();

                switch (messageType)
                {
                    case "0001":
                        response.Activations.Add(DeserializeActivation(jObject.ToString()));
                        break;
                    case "0002":
                        response.Cancellations.Add(DeserializeCancellation(jObject.ToString()));
                        break;
                    default:
                        response.Movements.Add(DeserializeMovement(jObject.ToString()));
                        break;
                }
            }

            return response;
        }

        private DeserializedJsonTrainMovement DeserializeMovement(string movement)
        {
            return string.IsNullOrWhiteSpace(movement) ? null : JsonConvert.DeserializeObject<DeserializedJsonTrainMovement>(movement);
        }

        private DeserializedJsonTrainCancellation DeserializeCancellation(string cancellation)
        {
            return string.IsNullOrWhiteSpace(cancellation) ? null : JsonConvert.DeserializeObject<DeserializedJsonTrainCancellation>(cancellation);
        }

        private DeserializedJsonTrainActivation DeserializeActivation(string activation)
        {
            return string.IsNullOrWhiteSpace(activation) ? null : JsonConvert.DeserializeObject<DeserializedJsonTrainActivation>(activation);
        }
    }
}
