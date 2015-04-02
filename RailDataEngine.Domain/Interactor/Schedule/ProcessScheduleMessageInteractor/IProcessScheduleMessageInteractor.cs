namespace RailDataEngine.Domain.Interactor.Schedule.ProcessScheduleMessageInteractor
{
    public interface IProcessScheduleMessageInteractor
    {
        void ProcessScheduleMessages(ProcessScheduleMessageInteractorRequest request);
    }
}
