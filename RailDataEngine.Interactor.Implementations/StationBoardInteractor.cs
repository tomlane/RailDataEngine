using System.Collections.Generic;
using RailDataEngine.Domain.Entity.StationBoard;
using RailDataEngine.Interactor.StationBoardInteractor;

namespace RailDataEngine.Interactor.Implementations
{
    public class StationBoardInteractor : IStationBoardInteractor
    {
        public List<Arrival> GetArrivals(StationBoardArrivalsInteractorRequest request)
        {
            throw new System.NotImplementedException();
        }

        public List<Departure> GetDepartures(StationBoardDeparturesInteractorRequest request)
        {
            throw new System.NotImplementedException();
        }

        public ServiceDetails GetServiceDetails(StationBoardServiceDetailsInteractorRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
