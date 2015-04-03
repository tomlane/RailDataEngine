namespace RailDataEngine.Domain.Interactors.TrainMovements.FetchMovementsInteractor
{
    public interface IFetchMovementsInteractor
    {
        FetchMovementsInteractorResponse FetchServiceMovements(FetchMovementsInteractorRequest request);
    }
}
