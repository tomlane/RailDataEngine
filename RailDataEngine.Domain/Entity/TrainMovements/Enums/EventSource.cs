using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.TrainMovements.Enums
{
    public enum EventSource
    {
        [Description("Automatic")]
        Automatic,

        [Description("Manual")]
        Manual
    }
}