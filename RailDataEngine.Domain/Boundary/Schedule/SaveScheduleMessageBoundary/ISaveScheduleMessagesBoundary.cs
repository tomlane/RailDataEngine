namespace RailDataEngine.Domain.Boundary.Schedule.SaveScheduleMessageBoundary
{
    public interface ISaveScheduleMessagesBoundary
    {
        void Invoke(SaveScheduleBoundaryRequest request);
    }
}
