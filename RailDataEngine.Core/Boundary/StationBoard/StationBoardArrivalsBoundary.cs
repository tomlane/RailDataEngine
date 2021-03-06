﻿using System;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardArrivalsBoundary;
using RailDataEngine.Domain.Interactor.StationBoardInteractor;

namespace RailDataEngine.Core.Boundary.StationBoard
{
    public class StationBoardArrivalsBoundary : IStationBoardArrivalsBoundary
    {
        private readonly IStationBoardInteractor _interactor;

        public StationBoardArrivalsBoundary(IStationBoardInteractor interactor)
        {
            if (interactor == null) throw new ArgumentNullException("interactor");
            _interactor = interactor;
        }

        public StationBoardArrivalsBoundaryResponse Invoke(StationBoardArrivalsBoundaryRequest request)
        {
            var arrivals = _interactor.GetArrivals(new StationBoardArrivalsInteractorRequest
            {
                Crs = request.Crs
            });

            return new StationBoardArrivalsBoundaryResponse
            {
                Services = arrivals.Services,
                StationName = arrivals.StationName
            };
        }
    }
}
