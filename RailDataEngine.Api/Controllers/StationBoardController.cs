using System;
using System.Net;
using System.Web.Http;
using Exceptionless;
using RailDataEngine.Api.ViewModels;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardArrivalsBoundary;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardDeparturesBoundary;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardServiceDetailsBoundary;

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
        public StationBoardArrivalsViewModel Arrivals(string crs)
        {
            if (string.IsNullOrEmpty(crs))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            try
            {
                var serviceResponse = _arrivalsBoundary.Invoke(new StationBoardArrivalsBoundaryRequest
                {
                    Crs = crs
                });

                return new StationBoardArrivalsViewModel
                {
                    Services = serviceResponse.Services,
                    StationName = serviceResponse.StationName
                };
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
        public StationBoardDeparturesViewModel Departures(string crs)
        {
            if (string.IsNullOrEmpty(crs))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            try
            {
                var serviceResponse = _departuresBoundary.Invoke(new StationBoardDeparturesBoundaryRequest
                {
                    Crs = crs
                });

                return new StationBoardDeparturesViewModel
                {
                    Services = serviceResponse.Services,
                    StationName = serviceResponse.StationName
                };
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
        public StationBoardServiceDetailsViewModel ServiceDetails(string serviceId)
        {
            if (string.IsNullOrEmpty(serviceId))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            try
            {
                var serviceResponse = _serviceDetailsBoundary.Invoke(new StationBoardServiceDetailsBoundaryRequest
                {
                    ServiceId = serviceId
                });

                return new StationBoardServiceDetailsViewModel
                {
                    ServiceDetails = serviceResponse.ServiceDetails
                };
            }
            catch (NotImplementedException exception)
            {
                exception.ToExceptionless().Submit();
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
        }
    }
}
