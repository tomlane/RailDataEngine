namespace RailDataEngine.Domain.Boundaries.TrainMovements.ProcessMovementMessageBoundary
{
    public interface IProcessMovementMessageBoundary
    {
        void Invoke(ProcessMovementMessageBoundaryRequest request);
    }
}
