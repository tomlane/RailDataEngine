using System;
using System.Linq;
using RailDataEngine.Domain.Gateway;
using RailDataEngine.Domain.Gateway.TrainMovements;
using RailDataEngine.Domain.Interactor.SaveMovementMessageInteractor;
using RailDataEngine.Domain.Services.MovementMessageConversionService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService;

namespace RailDataEngine.Interactor.Implementations
{
    public class SaveMovementMessageInteractor : ISaveMovementMessageInteractor
    {
        private readonly IMovementMessageDeserializationService _messageDeserializationService;
        private readonly IMovementMessageConversionService _messageConversionService;
        private readonly ITrainMovementGatewayContainer _movementGatewayContainer;

        public SaveMovementMessageInteractor(IMovementMessageDeserializationService movementMessageDeserializationService, IMovementMessageConversionService movementMessageConversionService, ITrainMovementGatewayContainer gatewayContainer)
        {
            if (movementMessageDeserializationService == null)
                throw new ArgumentNullException("movementMessageDeserializationService");
            if (movementMessageConversionService == null)
                throw new ArgumentNullException("movementMessageConversionService");
            if (gatewayContainer == null) 
                throw new ArgumentNullException("gatewayContainer");

            _messageDeserializationService = movementMessageDeserializationService;
            _messageConversionService = movementMessageConversionService;
            _movementGatewayContainer = gatewayContainer;
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

            if (convertedMessages.Activations.Any())
                _movementGatewayContainer.ActivationGateway.Create(convertedMessages.Activations);

            if (convertedMessages.Cancellations.Any())
                _movementGatewayContainer.CancellationGateway.Create(convertedMessages.Cancellations);
            
            if (convertedMessages.Movements.Any())
                _movementGatewayContainer.MovementGateway.Create(convertedMessages.Movements);
        }
    }
}
