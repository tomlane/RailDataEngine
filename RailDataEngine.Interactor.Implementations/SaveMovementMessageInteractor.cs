using System;
using RailDataEngine.Domain.Interactor.SaveMovementMessageInteractor;
using RailDataEngine.Domain.Services.MovementMessageConversionService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService;

namespace RailDataEngine.Interactor.Implementations
{
    public class SaveMovementMessageInteractor : ISaveMovementMessageInteractor
    {
        public SaveMovementMessageInteractor(IMovementMessageDeserializationService movementMessageDeserializationService, IMovementMessageConversionService movementMessageConversionService)
        {
            if (movementMessageDeserializationService == null)
                throw new ArgumentNullException("movementMessageDeserializationService");
            if (movementMessageConversionService == null)
                throw new ArgumentNullException("movementMessageConversionService");
        }

        public void SaveMovementMessages(SaveMovementMessageInteractorRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.MessageToSave))
                throw new ArgumentNullException("request");

            throw new System.NotImplementedException();
        }
    }
}
