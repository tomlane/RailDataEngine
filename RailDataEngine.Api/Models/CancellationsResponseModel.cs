using System.Collections.Generic;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Api.Models
{
    public class CancellationsResponseModel
    {
        public List<TrainCancellation> Cancellations { get; set; }
    }
}