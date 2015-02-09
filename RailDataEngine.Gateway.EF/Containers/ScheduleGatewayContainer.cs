using System;
using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Domain.Gateway;

namespace RailDataEngine.Gateway.EF.Containers
{
    public class ScheduleGatewayContainer : IScheduleGatewayContainer
    {
        public IStorageGateway<Association> AssociationGateway { get; set; }
        public IStorageGateway<Header> HeaderGateway { get; set; }
        public IStorageGateway<Location> LocationGateway { get; set; }
        public IStorageGateway<Record> RecordGateway { get; set; }
        public IStorageGateway<Tiploc> TiplocGateway { get; set; }

        public ScheduleGatewayContainer(
            IStorageGateway<Association> associationGateway,
            IStorageGateway<Header> headerGateway,
            IStorageGateway<Location> locationGateway,
            IStorageGateway<Record> recordGateway,
            IStorageGateway<Tiploc> tiplocGateway
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
