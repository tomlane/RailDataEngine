using System.Collections.Generic;
using RailDataEngine.Domain.Entities.StationBoard;

namespace RailDataEngine.Domain.Interactors.StationBoard.StationBoardArrivalsInteractor
{
    public class StationBoardArrivalsInteractorResponse
    {
        public string StationName { get; set; }
        public List<Arrival> Services { get; set; }
    }
}