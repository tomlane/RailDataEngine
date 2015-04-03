namespace RailDataEngine.Domain.Interactors.TrainMovements.FetchActivationsInteractor
{
    public interface IFetchActivationsInteractor
    {
        FetchActivationsInteractorResponse FetchActivations(FetchActivationsInteractorRequest request);
    }
}
