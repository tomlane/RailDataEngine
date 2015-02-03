using System.Collections.Generic;
using RailDataEngine.Domain.Entity.StationBoard;

namespace RailDataEngine.Domain.Services.StationBoardService
{
    public class StationDepartureResponse
    {
        public string StationName { get; set; }
        public List<Departure> Services { get; set; }
    }
}