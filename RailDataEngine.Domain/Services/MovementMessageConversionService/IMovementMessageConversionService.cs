namespace RailDataEngine.Domain.Services.MovementMessageConversionService
{
    public interface IMovementMessageConversionService
    {
        MovementMessageConversionResponse ConvertMovementMessages(MovementMessageConversionRequest request);
    }
}
