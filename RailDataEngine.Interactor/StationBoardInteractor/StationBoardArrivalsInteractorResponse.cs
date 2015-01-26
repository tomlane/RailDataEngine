using System.Collections.Generic;
using RailDataEngine.Domain.Entity.StationBoard;

namespace RailDataEngine.Interactor.StationBoardInteractor
{
    public class StationBoardArrivalsInteractorResponse
    {
        public string StationName { get; set; }
        public List<Arrival> Arrivals { get; set; }
    }
}