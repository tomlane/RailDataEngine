namespace RailDataEngine.Domain.Interactors.TrainMovements.ProcessMovementMessageInteractor
{
    public interface IProcessMovementMessageInteractor
    {
        void ProcessMovementMessages(ProcessMovementMessageInteractorRequest request);
    }
}
