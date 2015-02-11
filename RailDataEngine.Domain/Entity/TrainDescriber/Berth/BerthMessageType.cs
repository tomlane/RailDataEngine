using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.TrainDescriber.Berth
{
    public enum BerthMessageType
    {
        [Description("Berth Step")]
        BerthStep,

        [Description("Berth Cancel")]
        BerthCancel,

        [Description("Berth Interpose")]
        BerthInterpose,

        [Description("Heartbeat")]
        Heartbeat
    }
}