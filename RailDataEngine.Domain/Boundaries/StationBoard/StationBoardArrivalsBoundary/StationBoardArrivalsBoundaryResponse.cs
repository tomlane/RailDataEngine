using System.Collections.Generic;
using RailDataEngine.Domain.Entities.StationBoard;

namespace RailDataEngine.Domain.Boundaries.StationBoard.StationBoardArrivalsBoundary
{
    public class StationBoardArrivalsBoundaryResponse
    {
        public List<Arrival> Services { get; set; }
        public string StationName { get; set; }
    }
}