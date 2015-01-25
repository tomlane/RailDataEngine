using System.Collections.Generic;
using RailDataEngine.Domain.Entity.StationBoard;

namespace RailDataEngine.Interactor.StationBoardInteractor
{
    public interface IStationBoardInteractor
    {
        List<Arrival> GetArrivals(StationBoardArrivalsInteractorRequest request);
        List<Departure> GetDepartures(StationBoardDeparturesInteractorRequest request);
        ServiceDetails GetServiceDetails(StationBoardServiceDetailsInteractorRequest request);
    }
}
