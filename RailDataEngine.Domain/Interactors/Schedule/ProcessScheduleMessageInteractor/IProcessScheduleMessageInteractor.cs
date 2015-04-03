namespace RailDataEngine.Domain.Interactors.Schedule.ProcessScheduleMessageInteractor
{
    public interface IProcessScheduleMessageInteractor
    {
        void ProcessScheduleMessages(ProcessScheduleMessageInteractorRequest request);
    }
}
