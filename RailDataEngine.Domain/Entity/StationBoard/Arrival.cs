namespace RailDataEngine.Domain.Entity.StationBoard
{
    public class Arrival : StationBoardEntity
    {
        public string EstimatedArrival { get; set; }
        public string ScheduledArrival { get; set; }
    }
}
