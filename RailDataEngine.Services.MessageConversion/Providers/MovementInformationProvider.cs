using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Providers;

namespace RailDataEngine.Services.MessageConversion.Providers
{
    public class MovementInformationProvider : IMovementInformationProvider
    {
        public EventSource? GetEventSource(string eventSource)
        {
            if (string.IsNullOrWhiteSpace(eventSource))
                return null;

            switch (eventSource)
            {
                case "AUTOMATIC":
                    return EventSource.Automatic;
                default:
                    return EventSource.Manual;
            }
        }

        public VariationStatus? GetVariationStatus(string variationStatus)
        {
            if (string.IsNullOrWhiteSpace(variationStatus))
                return null;

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

        public EventType? GetEventType(string eventType)
        {
            if (string.IsNullOrWhiteSpace(eventType))
                return null;

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

        public CancellationType? GetCancellationType(string cancellationType)
        {
            if (string.IsNullOrWhiteSpace(cancellationType))
                return null;

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

        public TrainCallType? GetTrainCallType(string trainCallType)
        {
            if (string.IsNullOrWhiteSpace(trainCallType))
                return null;

            switch (trainCallType)
            {
                case "AUTOMATIC":
                    return TrainCallType.Automatic;
                default:
                    return TrainCallType.Manual;
            }
        }

        public Direction? GetTrainDirection(string direction)
        {
            if (string.IsNullOrWhiteSpace(direction))
                return null;

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
