using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Providers
{
    public interface IMovementInformationProvider
    {
        EventSource GetEventSource(string eventSource);
        VariationStatus GetVariationStatus(string variationStatus);
        EventType GetEventType(string eventType);
        CancellationType GetCancellationType(string cancellationType);
        TrainCallType GetTrainCallType(string trainCallType);
        Direction GetTrainDirection(string direction);
    }
}
