using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.Schedule
{
    public enum TrainClass
    {
        [Description("First and Standard Class")]
        FirstAndStandardClass,

        [Description("Standard Class Only")]
        StandardClassOnly
    }
}