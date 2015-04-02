using System.Collections.Generic;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Interactor.TrainMovements.FetchMovementsInteractor
{
    public class FetchMovementsInteractorResponse
    {
        public TrainActivation Activation { get; set; }
        public TrainCancellation Cancellation { get; set; }
        public List<TrainMovement> Movements { get; set; }
    }
}