using System;
using System.Net;
using System.Web.Http;
using RailDataEngine.Api.ViewModels;
using RailDataEngine.Domain.Boundary.Schedule.FetchScheduleMessageBoundary;

namespace RailDataEngine.Api.Controllers
{
    public class ScheduleController : ApiController
    {
        private IFetchScheduleMessagesBoundary _boundary;

        public ScheduleController(IFetchScheduleMessagesBoundary boundary)
        {
            if (boundary == null)
                throw new ArgumentNullException("boundary");

            _boundary = boundary;
        }

        /// <summary>
        /// Returns a list of schedule records from the datastore.
        /// </summary>
        /// <param name="trainUid">The train identifier of the schedule set.</param>
        /// <returns></returns>
        [HttpGet]
        public ScheduleRecordsViewModel Records(string trainUid)
        {
            if (string.IsNullOrWhiteSpace(trainUid))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var response = _boundary.Invoke(new FetchScheduleMessageBoundaryRequest
            {
                TrainUid = trainUid
            });

            return null;
        }
    }
}
