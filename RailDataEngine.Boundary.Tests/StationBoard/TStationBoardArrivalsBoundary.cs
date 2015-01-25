using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Boundary.Implementations.StationBoard;
using RailDataEngine.Boundary.StationBoard.StationBoardArrivalsBoundary;
using RailDataEngine.DI;
using RailDataEngine.Interactor.StationBoardInteractor;

namespace RailDataEngine.Boundary.Tests.StationBoard
{
    [TestFixture]
    class TStationBoardArrivalsBoundary
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var stationBoardInteractor = new Mock<IStationBoardInteractor>();

            Assert.Throws<ArgumentNullException>(() => new StationBoardArrivalsBoundary(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<IStationBoardArrivalsBoundary>();
            Assert.IsInstanceOf<StationBoardArrivalsBoundary>(boundary);
        }

        [TestFixture]
        class Invoke
        {
            [Test]
            public void calls_interactor()
            {
                var stationBoardInteractor = new Mock<IStationBoardInteractor>();

                var boundary = new StationBoardArrivalsBoundary(stationBoardInteractor.Object);

                boundary.Invoke(new StationBoardArrivalsBoundaryRequest
                {
                    Crs = "swi"
                });

                stationBoardInteractor.Verify(m => m.GetArrivals(It.IsAny<StationBoardArrivalsInteractorRequest>()), Times.Once);
            }
        }
    }
}
