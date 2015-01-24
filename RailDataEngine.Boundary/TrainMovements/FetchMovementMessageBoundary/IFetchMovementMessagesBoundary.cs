namespace RailDataEngine.Boundary.TrainMovements.FetchMovementMessageBoundary
{
    public interface IFetchMovementMessagesBoundary
    {
        FetchMovementMessagesBoundaryResponse Invoke(FetchMovementMessageBoundaryRequest request);
    }
}
