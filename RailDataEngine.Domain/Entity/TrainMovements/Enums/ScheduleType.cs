using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.TrainMovements.Enums
{
    public enum ScheduleType
    {
        [Description("Permanent Schedule")]
        Permanent,

        [Description("Overlay Schedule")]
        Overlay,

        [Description("New Schedule")]
        New,

        [Description("Schedule Cancellation")]
        Cancellation
    }
}