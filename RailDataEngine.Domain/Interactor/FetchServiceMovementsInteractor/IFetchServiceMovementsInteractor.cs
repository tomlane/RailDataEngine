namespace RailDataEngine.Domain.Interactor.FetchServiceMovementsInteractor
{
    public interface IFetchServiceMovementsInteractor
    {
        FetchServiceMovementsInteractorResponse FetchServiceMovements(FetchServiceMovementsInteractorRequest request);
    }
}
