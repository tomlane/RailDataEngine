namespace RailDataEngine.Domain.Interactor.Schedule.FetchScheduleInteractor
{
    public interface IFetchScheduleInteractor
    {
        FetchScheduleInteractorResponse FetchServiceSchedule(FetchScheduleInteractorRequest request);
    }
}
