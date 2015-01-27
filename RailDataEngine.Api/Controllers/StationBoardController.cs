using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Exceptionless;
using RailDataEngine.Boundary.StationBoard.StationBoardArrivalsBoundary;
using RailDataEngine.Boundary.StationBoard.StationBoardDeparturesBoundary;
using RailDataEngine.Boundary.StationBoard.StationBoardServiceDetailsBoundary;
using RailDataEngine.Domain.Entity.StationBoard;

namespace RailDataEngine.Api.Controllers
{
    public class StationBoardController : ApiController
    {
        private readonly IStationBoardArrivalsBoundary _arrivalsBoundary;
        private readonly IStationBoardDeparturesBoundary _departuresBoundary;
        private readonly IStationBoardServiceDetailsBoundary _serviceDetailsBoundary;

        public StationBoardController(IStationBoardArrivalsBoundary arrivalsBoundary, IStationBoardDeparturesBoundary departuresBoundary, IStationBoardServiceDetailsBoundary serviceDetailsBoundary)
        {
            if (arrivalsBoundary == null) throw new ArgumentNullException("arrivalsBoundary");
            if (departuresBoundary == null) throw new ArgumentNullException("departuresBoundary");
            if (serviceDetailsBoundary == null) throw new ArgumentNullException("serviceDetailsBoundary");

            _arrivalsBoundary = arrivalsBoundary;
            _departuresBoundary = departuresBoundary;
            _serviceDetailsBoundary = serviceDetailsBoundary;
        }

        /// <summary>
        /// Returns a list of arrivals for a station.
        /// </summary>
        /// <param name="crs">The CRS code for the requested station.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a list of departures for a station.
        /// </summary>
        /// <param name="crs">The CRS code for the requested station.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the details of a service.
        /// </summary>
        /// <param name="serviceId">The id of the service to be requested.</param>
        /// <returns></returns>
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
