namespace RailDataEngine.Domain.Interactor.FetchServiceScheduleInteractor
{
    public interface IFetchServiceScheduleInteractor
    {
        FetchServiceScheduleInteractorResponse FetchServiceSchedule(FetchServiceScheduleInteractorRequest request);
    }
}
