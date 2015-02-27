namespace RailDataEngine.Domain.Boundary.Schedule.FetchServiceScheduleBoundary
{
    public interface IFetchServiceScheduleBoundary
    {
        FetchServiceScheduleBoundaryResponse Invoke(FetchServiceScheduleBoundaryRequest request);
    }
}
