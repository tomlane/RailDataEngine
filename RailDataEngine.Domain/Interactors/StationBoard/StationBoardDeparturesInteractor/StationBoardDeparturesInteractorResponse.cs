using System.Collections.Generic;
using RailDataEngine.Domain.Entities.StationBoard;

namespace RailDataEngine.Domain.Interactors.StationBoard.StationBoardDeparturesInteractor
{
    public class StationBoardDeparturesInteractorResponse
    {
        public string StationName { get; set; }
        public List<Departure> Services { get; set; }
    }
}