using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;
using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Domain.Gateway.Schedule;

namespace RailDataEngine.UnitTests.Common
{
    public class MockHelpers
    {
        public static Mock<DbSet<T>> BuildMockSet<T>(IEnumerable<T> items) where T : class
        {
            IQueryable<T> data = items.AsQueryable();

            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }

        public static Mock<IScheduleGatewayContainer> BuildScheduleGatewayContainer()
        {
            var associationGateway = new Mock<IScheduleStorageGateway<Association>>();
            var headerGateway = new Mock<IScheduleStorageGateway<Header>>();
            var locationGateway = new Mock<IScheduleStorageGateway<Location>>();
            var recordGateway = new Mock<IScheduleStorageGateway<Record>>();
            var tiplocGateway = new Mock<IScheduleStorageGateway<Tiploc>>();

            var gatewayContainer = new Mock<IScheduleGatewayContainer>();

            gatewayContainer.Setup(m => m.AssociationGateway).Returns(associationGateway.Object);
            gatewayContainer.Setup(m => m.HeaderGateway).Returns(headerGateway.Object);
            gatewayContainer.Setup(m => m.LocationGateway).Returns(locationGateway.Object);
            gatewayContainer.Setup(m => m.RecordGateway).Returns(recordGateway.Object);
            gatewayContainer.Setup(m => m.TiplocGateway).Returns(tiplocGateway.Object);

            return gatewayContainer;
        }
    }
}
