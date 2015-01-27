using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Exceptionless;
using RailDataEngine.Boundary.StationBoard.StationBoardArrivalsBoundary;
using RailDataEngine.Boundary.StationBoard.StationBoardDeparturesBoundary;
using RailDataEngine.Boundary.StationBoard.StationBoardServiceDetailsBoundary;
using RailDataEngine.Domain.Entity.StationBoard;

namespace RailDataEngine.Api.Controllers
{
    public class StationBoardController : ApiController
    {
        private IStationBoardArrivalsBoundary _arrivalsBoundary;
        private IStationBoardDeparturesBoundary _departuresBoundary;
        private IStationBoardServiceDetailsBoundary _serviceDetailsBoundary;

        public StationBoardController(IStationBoardArrivalsBoundary arrivalsBoundary, IStationBoardDeparturesBoundary departuresBoundary, IStationBoardServiceDetailsBoundary serviceDetailsBoundary)
        {
            if (arrivalsBoundary == null) throw new ArgumentNullException("arrivalsBoundary");
            if (departuresBoundary == null) throw new ArgumentNullException("departuresBoundary");
            if (serviceDetailsBoundary == null) throw new ArgumentNullException("serviceDetailsBoundary");

            _arrivalsBoundary = arrivalsBoundary;
            _departuresBoundary = departuresBoundary;
            _serviceDetailsBoundary = serviceDetailsBoundary;
        }

        [HttpGet]
        public List<Arrival> Arrivals(string crs)
        {
            if (string.IsNullOrEmpty(crs))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            try
            {
                return _arrivalsBoundary.Invoke(new StationBoardArrivalsBoundaryRequest
                {
                    Crs = crs
                }).Services;
            }
            catch (NotImplementedException exception)
            {
                exception.ToExceptionless().Submit();
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
        }

        [HttpGet]
        public List<Departure> Departures(string crs)
        {
            if (string.IsNullOrEmpty(crs))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            try
            {
                return _departuresBoundary.Invoke(new StationBoardDeparturesBoundaryRequest
                {
                    Crs = crs
                }).Services;
            }
            catch (NotImplementedException exception)
            {
                exception.ToExceptionless().Submit();
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
        }

        [HttpGet]
        public ServiceDetails ServiceDetails(string serviceId)
        {
            if (string.IsNullOrEmpty(serviceId))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            try
            {
                return _serviceDetailsBoundary.Invoke(new StationBoardServiceDetailsBoundaryRequest
                {
                    ServiceId = serviceId
                }).ServiceDetails;
            }
            catch (NotImplementedException exception)
            {
                exception.ToExceptionless().Submit();
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
        }
    }
}
