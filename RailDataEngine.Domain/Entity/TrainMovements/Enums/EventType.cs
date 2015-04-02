using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.TrainMovements.Enums
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