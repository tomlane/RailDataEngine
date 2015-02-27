namespace RailDataEngine.Domain.Boundary.TrainMovements.FetchCancellationsBoundary
{
    public interface IFetchCancellationsBoundary
    {
        FetchCancellationsBoundaryResponse Invoke(FetchCancellationsBoundaryRequest request);
    }
}
