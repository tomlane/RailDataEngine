namespace RailDataEngine.Domain.Interactor.TrainMovements.FetchCancellationsInteractor
{
    public interface IFetchCancellationsInteractor
    {
        FetchCancellationsInteractorResponse FetchCancellations(FetchCancellationsInteractorRequest request);
    }
}
