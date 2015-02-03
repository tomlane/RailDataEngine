using RailDataEngine.Domain.Entity.Schedule;

namespace RailDataEngine.Domain.Gateway.Entity.Schedule
{
    public class TiplocEntity : Tiploc, IIdentifyable
    {
        public int Id { get; set; }
    }
}
