using System.Collections.Generic;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Interactor.FetchServiceMovementsInteractor
{
    public class FetchServiceMovementsInteractorResponse
    {
        public TrainActivation Activation { get; set; }
        public TrainCancellation Cancellation { get; set; }
        public List<TrainMovement> Movements { get; set; }
    }
}