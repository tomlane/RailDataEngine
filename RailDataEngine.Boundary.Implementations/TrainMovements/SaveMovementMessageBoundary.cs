using System;
using RailDataEngine.Domain.Boundary.TrainMovements.SaveMovementMessageBoundary;
using RailDataEngine.Domain.Interactor.SaveMovementMessageInteractor;

namespace RailDataEngine.Boundary.Implementations.TrainMovements
{
    public class SaveMovementMessageBoundary : ISaveMovementMessageBoundary
    {
        public SaveMovementMessageBoundary(ISaveMovementMessageInteractor interactor)
        {
            if (interactor == null)
                throw new ArgumentNullException("interactor");
        }

        public void Invoke(SaveMovementMessageBoundaryRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
