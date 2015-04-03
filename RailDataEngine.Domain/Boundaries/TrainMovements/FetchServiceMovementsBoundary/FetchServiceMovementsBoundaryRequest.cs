using System;

namespace RailDataEngine.Domain.Boundaries.TrainMovements.FetchServiceMovementsBoundary
{
    public class FetchServiceMovementsBoundaryRequest
    {
        public string TrainId { get; set; }
        public DateTime? Date { get; set; }
    }
}