using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.Schedule
{
    public enum DateIndicator
    {
        [Description("Standard")]
        Standard,

        [Description("Overnight")]
        Overnight,

        [Description("Previous Night")]
        PreviousNight
    }
}