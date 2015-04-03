using System.ComponentModel;

namespace RailDataEngine.Domain.Entities.TrainMovements.Enums
{
    public enum EventSource
    {
        [Description("Automatic")]
        Automatic,

        [Description("Manual")]
        Manual
    }
}