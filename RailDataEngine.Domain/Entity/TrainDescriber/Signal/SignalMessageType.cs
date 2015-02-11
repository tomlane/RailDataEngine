using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.TrainDescriber.Signal
{
    public enum SignalMessageType
    {
        [Description("Signal Update")]
        Update,

        [Description("Signal Refesh")]
        Refresh,

        [Description("Signal Refresh Finished")]
        RefreshFinished
    }
}