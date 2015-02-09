using System;
using RailDataEngine.Domain.Boundary.TrainMovements.SaveMovementMessageBoundary;
using RailDataEngine.Domain.Interactor.SaveMovementMessageInteractor;

namespace RailDataEngine.Boundary.Implementations.TrainMovements
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
            _interactor.SaveMovementMessages(new SaveMovementMessageInteractorRequest
            {
                MessageToSave = request.MessageToSave
            });
        }
    }
}
