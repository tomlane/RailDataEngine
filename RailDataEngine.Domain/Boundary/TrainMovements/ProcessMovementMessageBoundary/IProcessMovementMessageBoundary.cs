namespace RailDataEngine.Domain.Boundary.TrainMovements.ProcessMovementMessageBoundary
{
    public interface IProcessMovementMessageBoundary
    {
        void Invoke(ProcessMovementMessageBoundaryRequest request);
    }
}
