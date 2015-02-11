using RailDataEngine.Domain.Entity.Schedule;

namespace RailDataEngine.Domain.Gateway.Schedule
{
    public interface IScheduleGatewayContainer
    {
        IScheduleStorageGateway<Association> AssociationGateway { get; set; }
        IScheduleStorageGateway<Header> HeaderGateway { get; set; }
        IScheduleStorageGateway<Location> LocationGateway { get; set; }
        IScheduleStorageGateway<Record> RecordGateway { get; set; }
        IScheduleStorageGateway<Tiploc> TiplocGateway { get; set; }
    }
}
