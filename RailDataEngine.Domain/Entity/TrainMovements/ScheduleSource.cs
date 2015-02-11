using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.TrainMovements
{
    public enum ScheduleSource
    {
        [Description("CIF")]
        Cif,

        [Description("Very Short Term Plan")]
        Vstp
    }
}