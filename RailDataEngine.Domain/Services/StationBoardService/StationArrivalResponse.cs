using System.Collections.Generic;
using RailDataEngine.Domain.Entity.StationBoard;

namespace RailDataEngine.Domain.Services.StationBoardService
{
    public class StationArrivalResponse
    {
        public string StationName { get; set; }
        public List<Arrival> Services { get; set; }
    }
}