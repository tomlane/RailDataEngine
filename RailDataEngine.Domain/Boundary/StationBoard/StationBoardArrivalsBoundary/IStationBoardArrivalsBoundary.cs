﻿namespace RailDataEngine.Domain.Boundary.StationBoard.StationBoardArrivalsBoundary
{
    public interface IStationBoardArrivalsBoundary
    {
        StationBoardArrivalsBoundaryResponse Invoke(StationBoardArrivalsBoundaryRequest request);
    }
}
