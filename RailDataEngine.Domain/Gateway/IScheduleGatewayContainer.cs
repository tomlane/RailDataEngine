using RailDataEngine.Domain.Entity.Schedule;

namespace RailDataEngine.Domain.Gateway
{
    public interface IScheduleGatewayContainer
    {
        IStorageGateway<Association> AssociationGateway { get; set; }
        IStorageGateway<Header> HeaderGateway { get; set; }
        IStorageGateway<Location> LocationGateway { get; set; }
        IStorageGateway<Record> RecordGateway { get; set; }
        IStorageGateway<Tiploc> TiplocGateway { get; set; }
    }
}
