using System;

namespace RailDataEngine.Domain.Entity.Schedule
{
    public class Location
    {
        public LocationType LocationIdentity { get; set; }
        public string TiplocCode { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Pass { get; set; }
        public DateTime PublicArrival { get; set; }
        public DateTime PublicDeparture { get; set; }
        public string Platform { get; set; }
        public string Line { get; set; }
        public string Path { get; set; }
        public int EngineeringAllowance { get; set; }
        public int PathingAllowance { get; set; }
        public int PerformanceAllowance { get; set; }
        public LocationType LocationType { get; set; }
    }
}