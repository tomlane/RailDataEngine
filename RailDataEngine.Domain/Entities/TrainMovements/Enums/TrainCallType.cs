using System.ComponentModel;

namespace RailDataEngine.Domain.Entities.TrainMovements.Enums
{
    public enum TrainCallType
    {
        [Description("Automatic")]
        Automatic,

        [Description("Manual")]
        Manual
    }
}