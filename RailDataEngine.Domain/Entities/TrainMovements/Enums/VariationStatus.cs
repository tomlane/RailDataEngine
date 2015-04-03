using System.ComponentModel;

namespace RailDataEngine.Domain.Entities.TrainMovements.Enums
{
    public enum VariationStatus
    {
        [Description("On Time")]
        OnTime,

        [Description("Early")]
        Early,

        [Description("Late")]
        Late,

        [Description("Off Route")]
        OffRoute
    }
}