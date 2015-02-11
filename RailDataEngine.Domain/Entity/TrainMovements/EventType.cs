using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.TrainMovements
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