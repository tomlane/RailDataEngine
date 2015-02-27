using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Api.Controllers;
using RailDataEngine.Core;
using RailDataEngine.Domain.Boundary.Schedule.FetchServiceScheduleBoundary;
using RailDataEngine.Domain.Entity.Schedule;

namespace RailDataEngine.UnitTests.Api.Controllers
{
    [TestFixture]
    class TScheduleController
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var boundaryMock = new Mock<IFetchServiceScheduleBoundary>();

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
        class ServiceSchedule
        {
            [Test]
            public void throws_when_train_uid_null()
            {
                var boundaryMock = new Mock<IFetchServiceScheduleBoundary>();

                var controller = new ScheduleController(boundaryMock.Object);

                Assert.Throws<ArgumentNullException>(() => controller.ServiceSchedule(null, null));
            }

            [Test]
            public void calls_boundary()
            {
                var boundaryMock = new Mock<IFetchServiceScheduleBoundary>();

                boundaryMock.Setup(m => m.Invoke(It.IsAny<FetchServiceScheduleBoundaryRequest>()))
                    .Returns(new FetchServiceScheduleBoundaryResponse
                    {
                        Record = new Record()
                    });

                var controller = new ScheduleController(boundaryMock.Object);

                controller.ServiceSchedule("trainUid", new DateTime(2015, 02, 27, 14, 30, 0));

                boundaryMock.Verify(m => m.Invoke(It.Is<FetchServiceScheduleBoundaryRequest>(x => x.TrainUid == "trainUid" && x.Date == new DateTime(2015, 02, 27, 14, 30, 0))));
            }

            [Test]
            public void returns_result_from_boundary()
            {
                var boundaryMock = new Mock<IFetchServiceScheduleBoundary>();

                var fetchServiceScheduleBoundaryResponse = new FetchServiceScheduleBoundaryResponse
                {
                    Record = new Record
                    {
                        AtocCode = "FGW",
                        TrainUid = "trainUid",
                        StpIndicator = StpIndicator.Permanent
                    }
                };

                boundaryMock.Setup(m => m.Invoke(It.IsAny<FetchServiceScheduleBoundaryRequest>()))
                    .Returns(fetchServiceScheduleBoundaryResponse);

                var controller = new ScheduleController(boundaryMock.Object);

                var result = controller.ServiceSchedule("trainUid", new DateTime(2015, 02, 27, 14, 30, 0));

                Assert.AreEqual(fetchServiceScheduleBoundaryResponse.Record.AtocCode, result.Record.AtocCode);
                Assert.AreEqual(fetchServiceScheduleBoundaryResponse.Record.TrainUid, result.Record.TrainUid);
                Assert.AreEqual(fetchServiceScheduleBoundaryResponse.Record.StpIndicator, result.Record.StpIndicator);
            }
        }
    }
}
