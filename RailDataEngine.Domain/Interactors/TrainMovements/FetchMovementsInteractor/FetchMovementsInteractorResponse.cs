using System.Collections.Generic;
using RailDataEngine.Domain.Entities.TrainMovements;

namespace RailDataEngine.Domain.Interactors.TrainMovements.FetchMovementsInteractor
{
    public class FetchMovementsInteractorResponse
    {
        public TrainActivation Activation { get; set; }
        public TrainCancellation Cancellation { get; set; }
        public List<TrainMovement> Movements { get; set; }
    }
}