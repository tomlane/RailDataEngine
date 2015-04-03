namespace RailDataEngine.Domain.Boundaries.TrainMovements.FetchActivationsBoundary
{
    public interface IFetchActivationsBoundary
    {
        FetchActivationsBoundaryResponse Invoke(FetchActivationsBoundaryRequest request);
    }
}
