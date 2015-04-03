using System.ComponentModel;

namespace RailDataEngine.Domain.Entities.TrainMovements.Enums
{
    public enum EventType
    {
        [Description("Arrival")]
        Arrival,

        [Description("Departure")]
        Departure,

        [Description("Destination")]
        Destination
    }
}