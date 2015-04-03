namespace RailDataEngine.Domain.Interactors.StationBoard.StationBoardDeparturesInteractor
{
	public interface IStationBoardDeparturesInteractor
	{
		StationBoardDeparturesInteractorResponse GetDepartures(StationBoardDeparturesInteractorRequest request);
	}
}