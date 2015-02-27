using System;
using System.Web.Http;
using RailDataEngine.Api.Models;

namespace RailDataEngine.Api.Controllers
{
    public class TrainDescriberController : ApiController
    {
        [HttpGet]
        public BerthMessagesResponseModel BerthMessages(DateTime fromTime, DateTime toTime, string areaId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public SignalMessagesResponseModel SignalMessages(DateTime fromTime, DateTime toTime, string areaId)
        {
            throw new NotImplementedException();
        }
    }
}
