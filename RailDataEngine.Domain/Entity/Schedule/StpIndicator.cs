using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.Schedule
{
    public enum StpIndicator
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