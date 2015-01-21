namespace RailDataEngine.Domain.Entity.StationBoard
{
    public abstract class StationBoardEntity
    {
        public ServiceType? Type { get; set; }
        public string ServiceId { get; set; }
        public string Operator { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Platform { get; set; }
    }
}
