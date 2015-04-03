namespace RailDataEngine.Domain.Boundaries.StationBoard.StationBoardDeparturesBoundary
{
    public interface IStationBoardDeparturesBoundary
    {
        StationBoardDeparturesBoundaryResponse Invoke(StationBoardDeparturesBoundaryRequest request);
    }
}
