using System.Collections.Generic;
using RailDataEngine.Domain.Entity.StationBoard;

namespace RailDataEngine.Interactor.StationBoardInteractor
{
    public class StationBoardDeparturesInteractorResponse
    {
        public string StationName { get; set; }
        public List<Departure> Services { get; set; }
    }
}