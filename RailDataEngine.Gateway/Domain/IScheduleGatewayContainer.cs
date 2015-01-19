using RailDataEngine.Gateway.Entity.Schedule;

namespace RailDataEngine.Gateway.Domain
{
    public interface IScheduleGatewayContainer
    {
        IStorageGateway<AssociationEntity> AssociationGateway { get; set; }
        IStorageGateway<HeaderEntity> HeaderGateway { get; set; }
        IStorageGateway<LocationEntity> LocationGateway { get; set; }
        IStorageGateway<RecordEntity> RecordGateway { get; set; }
        IStorageGateway<TiplocEntity> TiplocGateway { get; set; }
    }
}
