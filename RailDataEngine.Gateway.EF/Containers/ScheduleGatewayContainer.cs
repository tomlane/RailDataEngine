using System;
using RailDataEngine.Domain.Gateway;
using RailDataEngine.Domain.Gateway.Entity.Schedule;

namespace RailDataEngine.Gateway.EF.Containers
{
    public class ScheduleGatewayContainer : IScheduleGatewayContainer
    {
        public IStorageGateway<AssociationEntity> AssociationGateway { get; set; }
        public IStorageGateway<HeaderEntity> HeaderGateway { get; set; }
        public IStorageGateway<LocationEntity> LocationGateway { get; set; }
        public IStorageGateway<RecordEntity> RecordGateway { get; set; }
        public IStorageGateway<TiplocEntity> TiplocGateway { get; set; }

        public ScheduleGatewayContainer(
            IStorageGateway<AssociationEntity> associationGateway,
            IStorageGateway<HeaderEntity> headerGateway,
            IStorageGateway<LocationEntity> locationGateway,
            IStorageGateway<RecordEntity> recordGateway,
            IStorageGateway<TiplocEntity> tiplocGateway
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
