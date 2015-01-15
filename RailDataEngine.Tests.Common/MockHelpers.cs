using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;

namespace RailDataEngine.Tests.Common
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
    }
}
