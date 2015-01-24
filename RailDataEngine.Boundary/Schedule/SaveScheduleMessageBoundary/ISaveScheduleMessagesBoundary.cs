namespace RailDataEngine.Boundary.SaveScheduleMessageBoundary
{
    public interface ISaveScheduleMessagesBoundary
    {
        void Invoke(SaveSchedulesBoundaryRequest request);
    }
}
