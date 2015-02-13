namespace RailDataEngine.Domain.Boundary.Schedule.FetchScheduleMessageBoundary
{
    public interface IFetchScheduleMessagesBoundary
    {
        FetchScheduleMessageBoundaryResponse Invoke(FetchScheduleMessageBoundaryRequest request);
    }
}
