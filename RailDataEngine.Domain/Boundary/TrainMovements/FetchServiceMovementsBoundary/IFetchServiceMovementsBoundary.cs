namespace RailDataEngine.Domain.Boundary.TrainMovements.FetchServiceMovementsBoundary
{
    public interface IFetchServiceMovementsBoundary
    {
        FetchServiceMovementsBoundaryResponse Invoke(FetchServiceMovementsBoundaryRequest request);
    }
}
