﻿using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RailDataEngine.Boundary.Implementations.StationBoard;
using RailDataEngine.Boundary.StationBoard.StationBoardServiceDetailsBoundary;
using RailDataEngine.DI;
using RailDataEngine.Domain.Entity.StationBoard;
using RailDataEngine.Interactor.StationBoardInteractor;

namespace RailDataEngine.Boundary.Tests.StationBoard
{
    [TestFixture]
    class TStationBoardServiceDetailsBoundary
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var interactor = new Mock<IStationBoardInteractor>();

            Assert.Throws<ArgumentNullException>(() => new StationBoardServiceDetailsBoundary(null));
        }

        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<IStationBoardServiceDetailsBoundary>();
            Assert.IsInstanceOf<StationBoardServiceDetailsBoundary>(boundary);
        }

        [TestFixture]
        class Invoke
        {
            [Test]
            public void calls_interactor()
            {
                var interactor = new Mock<IStationBoardInteractor>();

                interactor.Setup(m => m.GetServiceDetails(It.IsAny<StationBoardServiceDetailsInteractorRequest>()))
                    .Returns(new ServiceDetails());

                var boundary = new StationBoardServiceDetailsBoundary(interactor.Object);

                boundary.Invoke(new StationBoardServiceDetailsBoundaryRequest
                {
                    ServiceId = "serviceId"
                });

                interactor.Verify(m => m.GetServiceDetails(It.IsAny<StationBoardServiceDetailsInteractorRequest>()), Times.Once);
            }
        }
    }
}