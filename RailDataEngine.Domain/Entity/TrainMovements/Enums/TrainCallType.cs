using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.TrainMovements.Enums
{
    public enum TrainCallType
    {
        [Description("Automatic")]
        Automatic,

        [Description("Manual")]
        Manual
    }
}