using System.ComponentModel;

namespace RailDataEngine.Domain.Entities.Schedule.Enums
{
    public enum TrainClass
    {
        [Description("First and Standard Class")]
        FirstAndStandardClass,

        [Description("Standard Class Only")]
        StandardClassOnly
    }
}