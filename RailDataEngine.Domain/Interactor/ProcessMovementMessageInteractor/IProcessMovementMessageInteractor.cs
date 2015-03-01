namespace RailDataEngine.Domain.Interactor.ProcessMovementMessageInteractor
{
    public interface IProcessMovementMessageInteractor
    {
        void SaveMovementMessages(ProcessMovementMessageInteractorRequest request);
    }
}
