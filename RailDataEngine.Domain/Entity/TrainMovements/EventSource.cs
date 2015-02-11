using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.TrainMovements
{
    public enum EventSource
    {
        [Description("Automatic")]
        Automatic,

        [Description("Manual")]
        Manual
    }
}