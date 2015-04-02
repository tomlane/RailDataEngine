using System.Collections.Generic;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Interactor.TrainMovements.FetchActivationsInteractor
{
    public class FetchActivationsInteractorResponse
    {
        public List<TrainActivation> Activations { get; set; }
    }
}