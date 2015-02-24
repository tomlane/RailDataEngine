using System;
using System.Linq;
using RailDataEngine.Domain.Gateway.TrainMovements;
using RailDataEngine.Domain.Interactor.SaveMovementMessageInteractor;
using RailDataEngine.Domain.Services.MovementMessageConversionService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService;
using RailDataEngine.Domain.Services.MovementMessageStorageService;

namespace RailDataEngine.Core.Interactor.TrainMovements
{
    public class SaveMovementMessageInteractor : ISaveMovementMessageInteractor
    {
        private readonly IMovementMessageDeserializationService _messageDeserializationService;
        private readonly IMovementMessageConversionService _messageConversionService;
        private readonly IMovementMessageStorageService _messageStorageService;

        public SaveMovementMessageInteractor(IMovementMessageDeserializationService movementMessageDeserializationService, IMovementMessageConversionService movementMessageConversionService, IMovementMessageStorageService movementMessageStorageService)
        {
            if (movementMessageDeserializationService == null)
                throw new ArgumentNullException("movementMessageDeserializationService");
            if (movementMessageConversionService == null)
                throw new ArgumentNullException("movementMessageConversionService");
            if (movementMessageStorageService == null) 
                throw new ArgumentNullException("movementMessageStorageService");

            _messageDeserializationService = movementMessageDeserializationService;
            _messageConversionService = movementMessageConversionService;
            _messageStorageService = movementMessageStorageService;
        }

        public void SaveMovementMessages(SaveMovementMessageInteractorRequest request)
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

            _messageStorageService.SaveMovementMessages(new SaveMovementMessagesRequest
            {
                Activations = convertedMessages.Activations,
                Cancellations = convertedMessages.Cancellations,
                Movements = convertedMessages.Movements
            });
        }
    }
}
