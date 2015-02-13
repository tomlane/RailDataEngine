using System;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Api.Controllers;
using RailDataEngine.DI;
using RailDataEngine.Domain.Boundary.Schedule.FetchScheduleMessageBoundary;

namespace RailDataEngine.UnitTests.Api.Controllers
{
    [TestFixture]
    class TScheduleController
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var boundaryMock = new Mock<IFetchScheduleMessagesBoundary>();

            Assert.Throws<ArgumentNullException>(() => new ScheduleController(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var controller = container.Resolve<ScheduleController>();
            Assert.IsInstanceOf<ScheduleController>(controller);
        }

        [TestFixture]
        class Records
        {
            [Test]
            public void throws_on_bad_request()
            {
                var boundaryMock = new Mock<IFetchScheduleMessagesBoundary>();

                var controller = new ScheduleController(boundaryMock.Object);

                Assert.Throws<HttpResponseException>(() => controller.Records(null));
                Assert.Throws<HttpResponseException>(() => controller.Records(""));
            }

            [Test]
            public void calls_boundary()
            {
                var boundaryMock = new Mock<IFetchScheduleMessagesBoundary>();

                boundaryMock.Setup(m => m.Invoke(It.IsAny<FetchScheduleMessageBoundaryRequest>()))
                    .Returns(new FetchScheduleMessageBoundaryResponse());

                var controller = new ScheduleController(boundaryMock.Object);

                controller.Records("something");

                boundaryMock.Verify(m => m.Invoke(It.IsAny<FetchScheduleMessageBoundaryRequest>()), Times.Once);
            }
        }
    }
}
