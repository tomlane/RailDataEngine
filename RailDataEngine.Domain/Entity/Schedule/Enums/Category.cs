using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.Schedule.Enums
{
    public enum Category
    {
        [Description("Join")]
        Join,

        [Description("Divide")]
        Divide,

        [Description("Next")]
        Next
    }
}