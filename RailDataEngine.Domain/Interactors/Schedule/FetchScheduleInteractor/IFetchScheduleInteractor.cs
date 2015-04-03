namespace RailDataEngine.Domain.Interactors.Schedule.FetchScheduleInteractor
{
    public interface IFetchScheduleInteractor
    {
        FetchScheduleInteractorResponse FetchServiceSchedule(FetchScheduleInteractorRequest request);
    }
}
