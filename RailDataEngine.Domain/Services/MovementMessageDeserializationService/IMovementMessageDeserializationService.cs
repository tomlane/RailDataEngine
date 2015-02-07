namespace RailDataEngine.Domain.Services.MovementMessageDeserializationService
{
    public interface IMovementMessageDeserializationService
    {
        MovementMessageDeserializationResponse DeserializeMovementMessages(MovementMessageDeserializationRequest request);
    }
}
