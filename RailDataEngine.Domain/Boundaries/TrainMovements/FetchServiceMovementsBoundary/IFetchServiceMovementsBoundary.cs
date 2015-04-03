namespace RailDataEngine.Domain.Boundaries.TrainMovements.FetchServiceMovementsBoundary
{
    public interface IFetchServiceMovementsBoundary
    {
        FetchServiceMovementsBoundaryResponse Invoke(FetchServiceMovementsBoundaryRequest request);
    }
}
