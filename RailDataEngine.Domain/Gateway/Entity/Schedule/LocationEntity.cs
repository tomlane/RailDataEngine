using RailDataEngine.Domain.Entity.Schedule;

namespace RailDataEngine.Domain.Gateway.Entity.Schedule
{
    public class LocationEntity : Location, IIdentifyable
    {
        public int Id { get; set; }
    }
}
