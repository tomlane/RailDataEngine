namespace RailDataEngine.Domain.Interactors.TrainMovements.FetchCancellationsInteractor
{
    public interface IFetchCancellationsInteractor
    {
        FetchCancellationsInteractorResponse FetchCancellations(FetchCancellationsInteractorRequest request);
    }
}
