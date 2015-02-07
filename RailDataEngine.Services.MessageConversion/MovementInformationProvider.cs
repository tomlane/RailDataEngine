using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Providers;

namespace RailDataEngine.Services.MessageConversion
{
    public class MovementInformationProvider : IMovementInformationProvider
    {
        public EventSource GetEventSource(string eventSource)
        {
            switch (eventSource)
            {
                case "AUTOMATIC":
                    return EventSource.Automatic;
                default:
                    return EventSource.Manual;
            }
        }

        public VariationStatus GetVariationStatus(string variationStatus)
        {
            switch (variationStatus)
            {
                case "ON TIME":
                    return VariationStatus.OnTime;
                case "EARLY":
                    return VariationStatus.Early;
                case "LATE":
                    return VariationStatus.Late;
                default:
                    return VariationStatus.OffRoute;
            }
        }

        public EventType GetEventType(string eventType)
        {
            switch (eventType)
            {
                case "ARRIVAL":
                    return EventType.Arrival;
                case "DEPARTURE":
                    return EventType.Departure;
                default:
                    return EventType.Destination;
            }
        }

        public CancellationType GetCancellationType(string cancellationType)
        {
            switch (cancellationType)
            {
                case "ON CALL":
                    return CancellationType.OnCall;
                case "AT ORIGIN":
                    return CancellationType.AtOrigin;
                case "EN ROUTE":
                    return CancellationType.EnRoute;
                default:
                    return CancellationType.OutOfPlan;
            }
        }

        public TrainCallType GetTrainCallType(string trainCallType)
        {
            switch (trainCallType)
            {
                case "AUTOMATIC":
                    return TrainCallType.Automatic;
                default:
                    return TrainCallType.Manual;
            }
        }

        public Direction GetTrainDirection(string direction)
        {
            switch (direction)
            {
                case "UP":
                    return Direction.Up;
                default:
                    return Direction.Down;
            }
        }
    }
}
