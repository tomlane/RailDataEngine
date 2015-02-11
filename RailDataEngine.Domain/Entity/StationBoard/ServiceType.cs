using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.StationBoard
{
    public enum ServiceType
    {
        [Description("Train Service")]
        Train,

        [Description("Bus Service")]
        Bus,

        [Description("Ferry Service")]
        Ferry
    }
}