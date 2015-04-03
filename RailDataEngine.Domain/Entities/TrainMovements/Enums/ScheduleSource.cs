using System.ComponentModel;

namespace RailDataEngine.Domain.Entities.TrainMovements.Enums
{
    public enum ScheduleSource
    {
        [Description("CIF")]
        Cif,

        [Description("Very Short Term Plan")]
        Vstp
    }
}