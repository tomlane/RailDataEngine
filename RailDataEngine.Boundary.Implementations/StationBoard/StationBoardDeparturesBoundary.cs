﻿using System;
using RailDataEngine.Boundary.StationBoard.StationBoardDeparturesBoundary;
using RailDataEngine.Interactor.StationBoardInteractor;

namespace RailDataEngine.Boundary.Implementations.StationBoard
{
    public class StationBoardDeparturesBoundary : IStationBoardDeparturesBoundary
    {
        private IStationBoardInteractor _interactor;

        public StationBoardDeparturesBoundary(IStationBoardInteractor interactor)
        {
            if (interactor == null) throw new ArgumentNullException("interactor");
            _interactor = interactor;
        }

        public StationBoardDeparturesBoundaryResponse Invoke(StationBoardDeparturesBoundaryRequest request)
        {
            return new StationBoardDeparturesBoundaryResponse
            {
                Departures = _interactor.GetDepartures(new StationBoardDeparturesInteractorRequest
                {
                    Crs = request.Crs
                })
            };
        }
    }
}