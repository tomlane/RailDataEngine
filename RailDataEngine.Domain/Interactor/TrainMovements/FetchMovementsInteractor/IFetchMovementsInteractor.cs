namespace RailDataEngine.Domain.Interactor.TrainMovements.FetchMovementsInteractor
{
    public interface IFetchMovementsInteractor
    {
        FetchMovementsInteractorResponse FetchServiceMovements(FetchMovementsInteractorRequest request);
    }
}
