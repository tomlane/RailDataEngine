using System.Collections.Generic;
using RailDataEngine.Domain.Entities.TrainMovements;

namespace RailDataEngine.Domain.Interactors.TrainMovements.FetchActivationsInteractor
{
    public class FetchActivationsInteractorResponse
    {
        public List<TrainActivation> Activations { get; set; }
    }
}