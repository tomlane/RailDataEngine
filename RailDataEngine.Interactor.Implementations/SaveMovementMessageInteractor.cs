using System;
using RailDataEngine.Domain.Interactor.SaveMovementMessageInteractor;
using RailDataEngine.Domain.Services.MovementMessageConversionService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService;

namespace RailDataEngine.Interactor.Implementations
{
    public class SaveMovementMessageInteractor : ISaveMovementMessageInteractor
    {
        private readonly IMovementMessageDeserializationService _messageDeserializationService;
        private readonly IMovementMessageConversionService _messageConversionService;

        public SaveMovementMessageInteractor(IMovementMessageDeserializationService movementMessageDeserializationService, IMovementMessageConversionService movementMessageConversionService)
        {
            if (movementMessageDeserializationService == null)
                throw new ArgumentNullException("movementMessageDeserializationService");
            if (movementMessageConversionService == null)
                throw new ArgumentNullException("movementMessageConversionService");

            _messageDeserializationService = movementMessageDeserializationService;
            _messageConversionService = movementMessageConversionService;
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
        }
    }
}
