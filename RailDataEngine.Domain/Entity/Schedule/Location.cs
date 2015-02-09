using RailDataEngine.Domain.Gateway;

namespace RailDataEngine.Domain.Entity.Schedule
{
    public class Location : IIdentifyable
    {
        public int Id { get; set; }
        public LocationType? LocationIdentity { get; set; }
        public string TiplocCode { get; set; }
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public string Pass { get; set; }
        public string PublicArrival { get; set; }
        public string PublicDeparture { get; set; }
        public string Platform { get; set; }
        public string Line { get; set; }
        public string Path { get; set; }
        public int? EngineeringAllowance { get; set; }
        public int? PathingAllowance { get; set; }
        public int? PerformanceAllowance { get; set; }
        public LocationType? LocationType { get; set; }
    }
}