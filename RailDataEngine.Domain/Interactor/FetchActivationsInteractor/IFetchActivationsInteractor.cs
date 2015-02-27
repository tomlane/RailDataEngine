namespace RailDataEngine.Domain.Interactor.FetchActivationsInteractor
{
    public interface IFetchActivationsInteractor
    {
        FetchActivationsInteractorResponse FetchActivations(FetchActivationsInteractorRequest request);
    }
}
