using System;
using Newtonsoft.Json;
using RailDataEngine.Domain.Interactor.ProcessMovementMessageInteractor;
using RailDataEngine.Domain.Services.CloudQueueService;
using RailDataEngine.Domain.Services.MovementMessageConversionService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService;

namespace RailDataEngine.Core.Interactor.TrainMovements
{
    public class ProcessMovementMessageInteractor : IProcessMovementMessageInteractor
    {
        private readonly IMovementMessageDeserializationService _messageDeserializationService;
        private readonly IMovementMessageConversionService _messageConversionService;
        private readonly ICloudQueueService _cloudQueueService;

        public ProcessMovementMessageInteractor(IMovementMessageDeserializationService movementMessageDeserializationService, IMovementMessageConversionService movementMessageConversionService, ICloudQueueService cloudQueueService)
        {
            if (movementMessageDeserializationService == null)
                throw new ArgumentNullException("movementMessageDeserializationService");
            if (movementMessageConversionService == null)
                throw new ArgumentNullException("movementMessageConversionService");
            if (cloudQueueService == null)
                throw new ArgumentNullException("cloudQueueService");

            _messageDeserializationService = movementMessageDeserializationService;
            _messageConversionService = movementMessageConversionService;
            _cloudQueueService = cloudQueueService;
        }

        public void ProcessMovementMessages(ProcessMovementMessageInteractorRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.MessageToSave))
                throw new ArgumentNullException("request");

            var deserializedMessages =
                _messageDeserializationService.DeserializeMovementMessages(new MovementMessageDeserializationRequest
                {
                    MessageToDeserialize = request.MessageToSave
                });

            var convertedMessages =
                _messageConversionService.ConvertMovementMessages(new MovementMessageConversionRequest
                {
                    Activations = deserializedMessages.Activations,
                    Cancellations = deserializedMessages.Cancellations,
                    Movements = deserializedMessages.Movements
                });

            _cloudQueueService.AddToServiceBusQueue(new CloudQueueServiceRequest
            {
                MessageContent = JsonConvert.SerializeObject(convertedMessages)
            });
        }
    }
}
