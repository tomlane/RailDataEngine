using System;
using Exceptionless;
using RailDataEngine.Domain.Boundary.TrainMovements.SaveMovementMessageBoundary;
using RailDataEngine.Domain.Interactor.SaveMovementMessageInteractor;

namespace RailDataEngine.Core.Boundary.TrainMovements
{
    public class SaveMovementMessageBoundary : ISaveMovementMessageBoundary
    {
        private readonly ISaveMovementMessageInteractor _interactor;

        public SaveMovementMessageBoundary(ISaveMovementMessageInteractor interactor)
        {
            if (interactor == null)
                throw new ArgumentNullException("interactor");

            _interactor = interactor;
        }

        public void Invoke(SaveMovementMessageBoundaryRequest request)
        {
            try
            {
                _interactor.SaveMovementMessages(new SaveMovementMessageInteractorRequest
                {
                    MessageToSave = request.MessageToSave
                });
            }
            catch (Exception ex)
            {
                ex.ToExceptionless().AddObject(request).AddTags(new[]
                {
                    "Incoming message",
                    "Movement message"
                }).Submit();
            }

            
        }
    }
}
