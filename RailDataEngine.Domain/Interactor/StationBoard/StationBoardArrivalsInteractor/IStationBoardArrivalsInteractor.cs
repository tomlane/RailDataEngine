namespace RailDataEngine.Domain.Interactor.StationBoard.StationBoardArrivalsInteractor
{
	public interface IStationBoardArrivalsInteractor
	{
		StationBoardArrivalsInteractorResponse GetArrivals(StationBoardArrivalsInteractorRequest request);
	}
}