using System;
using System.Web.Http;
using RailDataEngine.Api.Models;
using RailDataEngine.Domain.Boundary.Schedule.FetchServiceScheduleBoundary;

namespace RailDataEngine.Api.Controllers
{
    public class ScheduleController : ApiController
    {
        private readonly IFetchServiceScheduleBoundary _boundary;

        public ScheduleController(IFetchServiceScheduleBoundary boundary)
        {
            if (boundary == null)
                throw new ArgumentNullException("boundary");

            _boundary = boundary;
        }

        [HttpGet]
        public ServiceScheduleResponseModel ServiceSchedule(string trainUid, DateTime? date)
        {
            if (string.IsNullOrEmpty(trainUid))
                throw new ArgumentNullException("trainUid");

            var result = _boundary.Invoke(new FetchServiceScheduleBoundaryRequest
            {
                Date = date,
                TrainUid = trainUid
            });

            return new ServiceScheduleResponseModel
            {
                Record = result.Record
            };
        }
    }
}
