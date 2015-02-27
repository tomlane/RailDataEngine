using System;

namespace RailDataEngine.Domain.Boundary.TrainMovements.FetchServiceMovementsBoundary
{
    public class FetchServiceMovementsBoundaryRequest
    {
        public string TrainId { get; set; }
        public DateTime? Date { get; set; }
    }
}