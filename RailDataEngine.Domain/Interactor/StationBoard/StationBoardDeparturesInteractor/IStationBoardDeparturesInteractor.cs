namespace RailDataEngine.Domain.Interactor.StationBoard.StationBoardDeparturesInteractor
{
	public interface IStationBoardDeparturesInteractor
	{
		StationBoardDeparturesInteractorResponse GetDepartures(StationBoardDeparturesInteractorRequest request);
	}
}