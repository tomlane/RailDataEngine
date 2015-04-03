namespace RailDataEngine.Domain.Boundaries.Schedule.ProcessScheduleMessageBoundary
{
    public interface IProcessScheduleMessageBoundary
    {
        void Invoke(ProcessScheduleBoundaryRequest request);
    }
}
