namespace RailDataEngine.Boundary.TrainMovements.SaveMovementMessageBoundary
{
    public interface ISaveMovementMessageBoundary
    {
        void Invoke(SaveMovementMessageBoundaryRequest request);
    }
}
