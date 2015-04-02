namespace RailDataEngine.Domain.Interactor.TrainMovements.ProcessMovementMessageInteractor
{
    public interface IProcessMovementMessageInteractor
    {
        void ProcessMovementMessages(ProcessMovementMessageInteractorRequest request);
    }
}
