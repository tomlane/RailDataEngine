using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.Schedule
{
    public enum Sleepers
    {
        [Description("First and Standard Sleepers")]
        FirstAndStandard,

        [Description("First Class Sleepers Only")]
        FirstClassOnly,

        [Description("Standard Class Sleepers Only")]
        StandardClassOnly
    }
}