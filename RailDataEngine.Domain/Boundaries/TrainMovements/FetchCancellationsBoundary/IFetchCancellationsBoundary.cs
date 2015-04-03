namespace RailDataEngine.Domain.Boundaries.TrainMovements.FetchCancellationsBoundary
{
    public interface IFetchCancellationsBoundary
    {
        FetchCancellationsBoundaryResponse Invoke(FetchCancellationsBoundaryRequest request);
    }
}
