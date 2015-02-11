using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.TrainMovements
{
    public enum TrainCallType
    {
        [Description("Automatic")]
        Automatic,

        [Description("Manual")]
        Manual
    }
}