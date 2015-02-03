using RailDataEngine.Domain.Entity.Schedule;

namespace RailDataEngine.Domain.Gateway.Entity.Schedule
{
    public class HeaderEntity : Header, IIdentifyable
    {
        public int Id { get; set; }
    }
}
