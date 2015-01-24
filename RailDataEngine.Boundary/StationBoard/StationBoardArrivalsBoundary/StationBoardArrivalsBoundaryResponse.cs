using System.Collections.Generic;
using RailDataEngine.Domain.Entity.StationBoard;

namespace RailDataEngine.Boundary.StationBoard.StationBoardArrivalsBoundary
{
    public class StationBoardArrivalsBoundaryResponse
    {
        public List<Arrival> Arrivals { get; set; }
    }
}