using System.Collections.Generic;
using RailDataEngine.Domain.Entity.StationBoard;

namespace RailDataEngine.Boundary.StationBoard.StationBoardDeparturesBoundary
{
    public class StationBoardDeparturesBoundaryResponse
    {
        public List<Departure> Services { get; set; }
        public string StationName { get; set; }
    }
}