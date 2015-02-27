using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Boundary.Schedule.FetchServiceScheduleBoundary;
using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Domain.Interactor.FetchServiceScheduleInteractor;

namespace RailDataEngine.UnitTests.Boundary.FetchServiceScheduleBoundary
{
    [TestFixture]
    class TFetchServiceScheduleBoundary
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var interactorMock = new Mock<IFetchServiceScheduleInteractor>();

            Assert.Throws<ArgumentNullException>(() => new Core.Boundary.Schedule.FetchServiceScheduleBoundary(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<IFetchServiceScheduleBoundary>();
            Assert.IsInstanceOf<Core.Boundary.Schedule.FetchServiceScheduleBoundary>(boundary);
        }

        [TestFixture]
        class Invoke
        {
            [Test]
            public void calls_interactor()
            {
                var interactorMock = new Mock<IFetchServiceScheduleInteractor>();
                var boundary = new Core.Boundary.Schedule.FetchServiceScheduleBoundary(interactorMock.Object);

                boundary.Invoke(new FetchServiceScheduleBoundaryRequest
                {
                    Date = new DateTime(2015, 02, 27, 14, 30, 0),
                    TrainUid = "trainUid"
                });

                interactorMock.Verify(m => m.FetchServiceSchedule(It.Is<FetchServiceScheduleInteractorRequest>(x => x.Date == new DateTime(2015, 02, 27, 14, 30, 0) && x.TrainUid == "trainUid")));
            }

            [Test]
            public void returns_result_from_interactor()
            {
                var interactorMock = new Mock<IFetchServiceScheduleInteractor>();

                var fetchServiceScheduleInteractorResponse = new FetchServiceScheduleInteractorResponse
                {
                    Record = new Record
                    {
                        AtocCode = "FGW",
                        TrainUid = "trainUid",
                        StpIndicator = StpIndicator.Permanent
                    }
                };

                interactorMock.Setup(m => m.FetchServiceSchedule(It.IsAny<FetchServiceScheduleInteractorRequest>()))
                    .Returns(fetchServiceScheduleInteractorResponse);

                var boundary = new Core.Boundary.Schedule.FetchServiceScheduleBoundary(interactorMock.Object);

                var result = boundary.Invoke(new FetchServiceScheduleBoundaryRequest
                {
                    Date = new DateTime(2015, 02, 27, 14, 30, 0),
                    TrainUid = "trainUid"
                });

                Assert.AreEqual(fetchServiceScheduleInteractorResponse.Record.AtocCode, result.Record.AtocCode);
                Assert.AreEqual(fetchServiceScheduleInteractorResponse.Record.TrainUid, result.Record.TrainUid);
                Assert.AreEqual(fetchServiceScheduleInteractorResponse.Record.StpIndicator, result.Record.StpIndicator);
            }
        }
    }
}
