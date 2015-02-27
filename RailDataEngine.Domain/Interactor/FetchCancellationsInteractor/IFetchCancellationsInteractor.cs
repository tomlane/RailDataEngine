namespace RailDataEngine.Domain.Interactor.FetchCancellationsInteractor
{
    public interface IFetchCancellationsInteractor
    {
        FetchCancellationsInteractorResponse FetchCancellations(FetchCancellationsInteractorRequest request);
    }
}
