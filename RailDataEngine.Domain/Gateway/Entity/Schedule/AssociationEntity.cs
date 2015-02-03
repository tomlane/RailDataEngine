using RailDataEngine.Domain.Entity.Schedule;

namespace RailDataEngine.Domain.Gateway.Entity.Schedule
{
    public class AssociationEntity : Association, IIdentifyable
    {
        public int Id { get; set; }
    }
}
