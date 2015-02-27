using System.Collections.Generic;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Api.Models
{
    public class ActivationsResponseModel
    {
        public List<TrainActivation> Activations { get; set; }
    }
}