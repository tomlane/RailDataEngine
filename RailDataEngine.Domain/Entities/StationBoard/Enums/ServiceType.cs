using System.ComponentModel;

namespace RailDataEngine.Domain.Entities.StationBoard.Enums
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