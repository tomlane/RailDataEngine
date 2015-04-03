using System;

namespace RailDataEngine.Domain.Boundaries.TrainMovements.FetchCancellationsBoundary
{
    public class FetchCancellationsBoundaryRequest
    {
        public DateTime? Date { get; set; }
    }
}