namespace RailDataEngine.Interactor.StationBoardInteractor
{
    public interface IStationBoardInteractor
    {
        StationBoardArrivalsInteractorResponse GetArrivals(StationBoardArrivalsInteractorRequest request);
        StationBoardDeparturesInteractorResponse GetDepartures(StationBoardDeparturesInteractorRequest request);
        StationBoardServiceDetailsInteractorResponse GetServiceDetails(StationBoardServiceDetailsInteractorRequest request);
    }
}
