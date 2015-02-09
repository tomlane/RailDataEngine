using System;
using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Domain.Gateway;

namespace RailDataEngine.Gateway.EF.Containers
{
    public class ScheduleGatewayContainer : IScheduleGatewayContainer
    {
        public IScheduleStorageGateway<Association> AssociationGateway { get; set; }
        public IScheduleStorageGateway<Header> HeaderGateway { get; set; }
        public IScheduleStorageGateway<Location> LocationGateway { get; set; }
        public IScheduleStorageGateway<Record> RecordGateway { get; set; }
        public IScheduleStorageGateway<Tiploc> TiplocGateway { get; set; }

        public ScheduleGatewayContainer(
            IScheduleStorageGateway<Association> associationGateway,
            IScheduleStorageGateway<Header> headerGateway,
            IScheduleStorageGateway<Location> locationGateway,
            IScheduleStorageGateway<Record> recordGateway,
            IScheduleStorageGateway<Tiploc> tiplocGateway
            )
        {
            if (associationGateway == null) throw new ArgumentNullException("associationGateway");
            if (headerGateway == null) throw new ArgumentNullException("headerGateway");
            if (locationGateway == null) throw new ArgumentNullException("locationGateway");
            if (recordGateway == null) throw new ArgumentNullException("recordGateway");
            if (tiplocGateway == null) throw new ArgumentNullException("tiplocGateway");

            AssociationGateway = associationGateway;
            HeaderGateway = headerGateway;
            LocationGateway = locationGateway;
            RecordGateway = recordGateway;
            TiplocGateway = tiplocGateway;
        }
    }
}
