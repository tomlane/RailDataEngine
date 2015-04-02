using System.Collections.Generic;
using RailDataEngine.Domain.Entity.StationBoard;

namespace RailDataEngine.Domain.Interactor.StationBoard.StationBoardArrivalsInteractor
{
    public class StationBoardArrivalsInteractorResponse
    {
        public string StationName { get; set; }
        public List<Arrival> Services { get; set; }
    }
}