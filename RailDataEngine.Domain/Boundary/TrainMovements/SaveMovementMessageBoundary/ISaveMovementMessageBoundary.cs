namespace RailDataEngine.Domain.Boundary.TrainMovements.SaveMovementMessageBoundary
{
    public interface ISaveMovementMessageBoundary
    {
        void Invoke(SaveMovementMessageBoundaryRequest request);
    }
}
