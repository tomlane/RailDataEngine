using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.Schedule.Enums
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