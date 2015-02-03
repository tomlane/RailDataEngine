namespace RailDataEngine.Domain.Boundary.StationBoard.StationBoardDeparturesBoundary
{
    public interface IStationBoardDeparturesBoundary
    {
        StationBoardDeparturesBoundaryResponse Invoke(StationBoardDeparturesBoundaryRequest request);
    }
}
