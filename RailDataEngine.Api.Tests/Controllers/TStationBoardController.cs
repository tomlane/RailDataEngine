using System;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Api.Controllers;
using RailDataEngine.DI;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardArrivalsBoundary;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardDeparturesBoundary;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardServiceDetailsBoundary;

namespace RailDataEngine.Api.Tests.Controllers
{
    [TestFixture]
    class TStationBoardController
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var arrivalsBoundary = new Mock<IStationBoardArrivalsBoundary>();
            var departuresBoundary = new Mock<IStationBoardDeparturesBoundary>();
            var serviceDetailsBoundary = new Mock<IStationBoardServiceDetailsBoundary>();

            Assert.Throws<ArgumentNullException>(() => new StationBoardController(null, departuresBoundary.Object, serviceDetailsBoundary.Object));
            Assert.Throws<ArgumentNullException>(() => new StationBoardController(arrivalsBoundary.Object, null, serviceDetailsBoundary.Object));
            Assert.Throws<ArgumentNullException>(() => new StationBoardController(arrivalsBoundary.Object, departuresBoundary.Object, null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var controller = container.Resolve<StationBoardController>();
            Assert.IsInstanceOf<StationBoardController>(controller);
        }

        [TestFixture]
        class Arrivals
        {
            [Test]
            public void calls_boundary()
            {
                var arrivalsBoundary = new Mock<IStationBoardArrivalsBoundary>();
                var departuresBoundary = new Mock<IStationBoardDeparturesBoundary>();
                var serviceDetailsBoundary = new Mock<IStationBoardServiceDetailsBoundary>();

                arrivalsBoundary.Setup(m => m.Invoke(It.IsAny<StationBoardArrivalsBoundaryRequest>()))
                    .Returns(new StationBoardArrivalsBoundaryResponse());

                var controller = new StationBoardController(arrivalsBoundary.Object, departuresBoundary.Object,
                    serviceDetailsBoundary.Object);

                controller.Arrivals("swi");

                arrivalsBoundary.Verify(m => m.Invoke(It.IsAny<StationBoardArrivalsBoundaryRequest>()), Times.Once);
            }

            [Test]
            public void throws_on_bad_request()
            {
                var arrivalsBoundary = new Mock<IStationBoardArrivalsBoundary>();
                var departuresBoundary = new Mock<IStationBoardDeparturesBoundary>();
                var serviceDetailsBoundary = new Mock<IStationBoardServiceDetailsBoundary>();

                var controller = new StationBoardController(arrivalsBoundary.Object, departuresBoundary.Object,
                    serviceDetailsBoundary.Object);

                Assert.Throws<HttpResponseException>(() => controller.Arrivals(null));
                Assert.Throws<HttpResponseException>(() => controller.Arrivals(""));
            }

            [Test]
            public void throws_not_implemented_code()
            {
                var arrivalsBoundary = new Mock<IStationBoardArrivalsBoundary>();
                var departuresBoundary = new Mock<IStationBoardDeparturesBoundary>();
                var serviceDetailsBoundary = new Mock<IStationBoardServiceDetailsBoundary>();

                arrivalsBoundary.Setup(m => m.Invoke(It.IsAny<StationBoardArrivalsBoundaryRequest>()))
                    .Throws<NotImplementedException>();

                var controller = new StationBoardController(arrivalsBoundary.Object, departuresBoundary.Object,
                    serviceDetailsBoundary.Object);

                Assert.Throws<HttpResponseException>(() => controller.Arrivals("swi"));
            }
        }

        [TestFixture]
        class Departures
        {
            [Test]
            public void calls_boundary()
            {
                var arrivalsBoundary = new Mock<IStationBoardArrivalsBoundary>();
                var departuresBoundary = new Mock<IStationBoardDeparturesBoundary>();
                var serviceDetailsBoundary = new Mock<IStationBoardServiceDetailsBoundary>();

                departuresBoundary.Setup(m => m.Invoke(It.IsAny<StationBoardDeparturesBoundaryRequest>()))
                    .Returns(new StationBoardDeparturesBoundaryResponse());

                var controller = new StationBoardController(arrivalsBoundary.Object, departuresBoundary.Object,
                    serviceDetailsBoundary.Object);

                controller.Departures("swi");

                departuresBoundary.Verify(m => m.Invoke(It.IsAny<StationBoardDeparturesBoundaryRequest>()), Times.Once);
            }

            [Test]
            public void throws_on_bad_request()
            {
                var arrivalsBoundary = new Mock<IStationBoardArrivalsBoundary>();
                var departuresBoundary = new Mock<IStationBoardDeparturesBoundary>();
                var serviceDetailsBoundary = new Mock<IStationBoardServiceDetailsBoundary>();

                var controller = new StationBoardController(arrivalsBoundary.Object, departuresBoundary.Object,
                    serviceDetailsBoundary.Object);

                Assert.Throws<HttpResponseException>(() => controller.Departures(null));
                Assert.Throws<HttpResponseException>(() => controller.Departures(""));
            }

            [Test]
            public void throws_not_implemented_code()
            {
                var arrivalsBoundary = new Mock<IStationBoardArrivalsBoundary>();
                var departuresBoundary = new Mock<IStationBoardDeparturesBoundary>();
                var serviceDetailsBoundary = new Mock<IStationBoardServiceDetailsBoundary>();

                departuresBoundary.Setup(m => m.Invoke(It.IsAny<StationBoardDeparturesBoundaryRequest>()))
                    .Throws<NotImplementedException>();

                var controller = new StationBoardController(arrivalsBoundary.Object, departuresBoundary.Object,
                    serviceDetailsBoundary.Object);

                Assert.Throws<HttpResponseException>(() => controller.Departures("swi"));
            }
        }

        [TestFixture]
        class ServiceDetails
        {
            [Test]
            public void calls_boundary()
            {
                var arrivalsBoundary = new Mock<IStationBoardArrivalsBoundary>();
                var departuresBoundary = new Mock<IStationBoardDeparturesBoundary>();
                var serviceDetailsBoundary = new Mock<IStationBoardServiceDetailsBoundary>();

                serviceDetailsBoundary.Setup(m => m.Invoke(It.IsAny<StationBoardServiceDetailsBoundaryRequest>()))
                    .Returns(new StationBoardServiceDetailsBoundaryResponse());

                var controller = new StationBoardController(arrivalsBoundary.Object, departuresBoundary.Object,
                    serviceDetailsBoundary.Object);

                controller.ServiceDetails("serviceId");

                serviceDetailsBoundary.Verify(m => m.Invoke(It.IsAny<StationBoardServiceDetailsBoundaryRequest>()), Times.Once);
            }

            [Test]
            public void throws_on_bad_request()
            {
                var arrivalsBoundary = new Mock<IStationBoardArrivalsBoundary>();
                var departuresBoundary = new Mock<IStationBoardDeparturesBoundary>();
                var serviceDetailsBoundary = new Mock<IStationBoardServiceDetailsBoundary>();

                var controller = new StationBoardController(arrivalsBoundary.Object, departuresBoundary.Object,
                    serviceDetailsBoundary.Object);

                Assert.Throws<HttpResponseException>(() => controller.ServiceDetails(null));
                Assert.Throws<HttpResponseException>(() => controller.ServiceDetails(""));
            }

            [Test]
            public void throws_not_implemented_code()
            {
                var arrivalsBoundary = new Mock<IStationBoardArrivalsBoundary>();
                var departuresBoundary = new Mock<IStationBoardDeparturesBoundary>();
                var serviceDetailsBoundary = new Mock<IStationBoardServiceDetailsBoundary>();

                serviceDetailsBoundary.Setup(m => m.Invoke(It.IsAny<StationBoardServiceDetailsBoundaryRequest>()))
                    .Throws<NotImplementedException>();

                var controller = new StationBoardController(arrivalsBoundary.Object, departuresBoundary.Object,
                    serviceDetailsBoundary.Object);

                Assert.Throws<HttpResponseException>(() => controller.ServiceDetails("swi"));
            }
        }
    }
}
