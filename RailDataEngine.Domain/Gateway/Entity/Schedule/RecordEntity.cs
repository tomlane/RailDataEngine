using System.Collections.Generic;
using RailDataEngine.Domain.Entity.Schedule;

namespace RailDataEngine.Domain.Gateway.Entity.Schedule
{
    public class RecordEntity : Record, IIdentifyable
    {
        public int Id { get; set; }
        public List<LocationEntity> Locations { get; set; }
    }
}
