using System.Collections.Generic;
using RailDataEngine.Domain.Entity.StationBoard;

namespace RailDataEngine.Domain.Boundary.StationBoard.StationBoardArrivalsBoundary
{
    public class StationBoardArrivalsBoundaryResponse
    {
        public List<Arrival> Services { get; set; }
        public string StationName { get; set; }
    }
}