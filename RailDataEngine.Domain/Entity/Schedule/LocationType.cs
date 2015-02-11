using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.Schedule
{
    public enum LocationType
    {
        [Description("Originating")]
        Originating,

        [Description("Intermediate")]
        Intermediate,

        [Description("Terminating")]
        Terminating
    }
}