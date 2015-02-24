namespace RailDataEngine.Domain.Services.MovementMessageStorageService
{
    public interface IMovementMessageStorageService
    {
        void SaveMovementMessages(SaveMovementMessagesRequest request);
    }
}
