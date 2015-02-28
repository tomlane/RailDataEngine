using System;
using System.Web.Http;
using RailDataEngine.Api.Models;
using RailDataEngine.Domain.Boundary.TrainMovements.FetchActivationsBoundary;
using RailDataEngine.Domain.Boundary.TrainMovements.FetchCancellationsBoundary;
using RailDataEngine.Domain.Boundary.TrainMovements.FetchServiceMovementsBoundary;

namespace RailDataEngine.Api.Controllers
{
    public class TrainMovementController : ApiController
    {
        private readonly IFetchActivationsBoundary _activationsBoundary;
        private readonly IFetchCancellationsBoundary _cancellationsBoundary;
        private readonly IFetchServiceMovementsBoundary _serviceMovementsBoundary;

        public TrainMovementController(IFetchActivationsBoundary activationsBoundary, IFetchCancellationsBoundary cancellationsBoundary, IFetchServiceMovementsBoundary serviceMovementsBoundary)
        {
            if (activationsBoundary == null)
                throw new ArgumentNullException("activationsBoundary");

            if (cancellationsBoundary == null)
                throw new ArgumentNullException("cancellationsBoundary");

            if (serviceMovementsBoundary == null)
                throw new ArgumentNullException("serviceMovementsBoundary");

            _activationsBoundary = activationsBoundary;
            _cancellationsBoundary = cancellationsBoundary;
            _serviceMovementsBoundary = serviceMovementsBoundary;
        }

        [HttpGet]
        public ActivationsResponseModel Activations()
        {
            var result = _activationsBoundary.Invoke(new FetchActivationsBoundaryRequest());

            return new ActivationsResponseModel
            {
                Activations = result.Activations
            };
        }

        [HttpGet]
        public CancellationsResponseModel Cancellations()
        {
            var result = _cancellationsBoundary.Invoke(new FetchCancellationsBoundaryRequest());

            return new CancellationsResponseModel
            {
                Cancellations = result.Cancellations
            };
        }

        [HttpGet]
        public ServiceMovementResponseModel ServiceMovements(string trainId)
        {
            if (string.IsNullOrEmpty(trainId))
                throw new ArgumentNullException("trainId");

            var result = _serviceMovementsBoundary.Invoke(new FetchServiceMovementsBoundaryRequest
            {
                TrainId = trainId
            });

            return new ServiceMovementResponseModel
            {
                Activation = result.Activation,
                Cancellation = result.Cancellation,
                Movements = result.Movements
            };
        }
    }
}
