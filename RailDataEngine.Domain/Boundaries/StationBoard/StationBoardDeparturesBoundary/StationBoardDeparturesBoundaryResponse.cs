using System.Collections.Generic;
using RailDataEngine.Domain.Entities.StationBoard;

namespace RailDataEngine.Domain.Boundaries.StationBoard.StationBoardDeparturesBoundary
{
    public class StationBoardDeparturesBoundaryResponse
    {
        public List<Departure> Services { get; set; }
        public string StationName { get; set; }
    }
}