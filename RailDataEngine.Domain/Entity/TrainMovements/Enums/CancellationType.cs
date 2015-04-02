using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.TrainMovements.Enums
{
    public enum CancellationType
    {
        [Description("On Call")]
        OnCall,

        [Description("At Origin")]
        AtOrigin,

        [Description("En Route")]
        EnRoute,

        [Description("Out of Plan")]
        OutOfPlan
    }
}