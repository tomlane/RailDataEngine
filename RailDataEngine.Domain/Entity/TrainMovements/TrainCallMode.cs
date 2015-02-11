using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.TrainMovements
{
    public enum TrainCallMode
    {
        [Description("Normal")]
        Normal,

        [Description("Overnight")]
        Overnight
    }
}