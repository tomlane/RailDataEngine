using System;

namespace RailDataEngine.Domain.Boundary.TrainMovements.FetchCancellationsBoundary
{
    public class FetchCancellationsBoundaryRequest
    {
        public DateTime? Date { get; set; }
    }
}