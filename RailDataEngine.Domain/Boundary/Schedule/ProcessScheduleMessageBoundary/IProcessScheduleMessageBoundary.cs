namespace RailDataEngine.Domain.Boundary.Schedule.ProcessScheduleMessageBoundary
{
    public interface IProcessScheduleMessageBoundary
    {
        void Invoke(ProcessScheduleBoundaryRequest request);
    }
}
