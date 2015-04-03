using System.ComponentModel;

namespace RailDataEngine.Domain.Entities.TrainMovements.Enums
{
    public enum TrainCallMode
    {
        [Description("Normal")]
        Normal,

        [Description("Overnight")]
        Overnight
    }
}