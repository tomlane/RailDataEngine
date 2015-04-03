namespace RailDataEngine.Domain.Interactors.StationBoard.StationBoardArrivalsInteractor
{
	public interface IStationBoardArrivalsInteractor
	{
		StationBoardArrivalsInteractorResponse GetArrivals(StationBoardArrivalsInteractorRequest request);
	}
}