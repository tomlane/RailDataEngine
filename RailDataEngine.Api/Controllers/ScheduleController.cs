using System;
using System.Web.Http;
using RailDataEngine.Api.Models;

namespace RailDataEngine.Api.Controllers
{
    public class ScheduleController : ApiController
    {
        [HttpGet]
        public ServiceScheduleResponseModel ServiceSchedule(string trainId, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
