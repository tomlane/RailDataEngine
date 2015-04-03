namespace RailDataEngine.Domain.Boundaries.StationBoard.StationBoardArrivalsBoundary
{
    public interface IStationBoardArrivalsBoundary
    {
        StationBoardArrivalsBoundaryResponse Invoke(StationBoardArrivalsBoundaryRequest request);
    }
}
