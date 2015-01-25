namespace RailDataEngine.Services.StationBoardService
{
    public interface IStationBoardService
    {
        StationArrivalResponse GetArrivals(StationBoardRequest request);
        StationDepartureResponse GetDepartures(StationBoardRequest request);
        ServiceDetailsResponse GetServiceDetails(ServiceDetailsRequest request);
    }
}
