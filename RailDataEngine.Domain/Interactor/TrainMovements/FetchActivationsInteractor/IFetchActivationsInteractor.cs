namespace RailDataEngine.Domain.Interactor.TrainMovements.FetchActivationsInteractor
{
    public interface IFetchActivationsInteractor
    {
        FetchActivationsInteractorResponse FetchActivations(FetchActivationsInteractorRequest request);
    }
}
