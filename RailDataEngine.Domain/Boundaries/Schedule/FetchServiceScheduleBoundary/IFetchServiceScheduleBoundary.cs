namespace RailDataEngine.Domain.Boundaries.Schedule.FetchServiceScheduleBoundary
{
    public interface IFetchServiceScheduleBoundary
    {
        FetchServiceScheduleBoundaryResponse Invoke(FetchServiceScheduleBoundaryRequest request);
    }
}
