using System.ComponentModel;

namespace RailDataEngine.Domain.Entities.Schedule.Enums
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