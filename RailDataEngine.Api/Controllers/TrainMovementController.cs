using System;
using System.Web.Http;
using RailDataEngine.Api.Models;

namespace RailDataEngine.Api.Controllers
{
    public class TrainMovementController : ApiController
    {
        [HttpGet]
        public ActivationsResponseModel Activations(DateTime date)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public CancellationsResponseModel Cancellations(DateTime date)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ServiceMovementResponseModel Movements(string trainId, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
