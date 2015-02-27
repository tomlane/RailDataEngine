namespace RailDataEngine.Domain.Boundary.TrainMovements.FetchActivationsBoundary
{
    public interface IFetchActivationsBoundary
    {
        FetchActivationsBoundaryResponse Invoke(FetchActivationsBoundaryRequest request);
    }
}
