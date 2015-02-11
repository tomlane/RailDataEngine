using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.Schedule
{
    public enum CateringCode
    {
        [Description("Buffet Service")]
        BuffetService,

        [Description("First Class Restaurant")]
        FirstClassRestaurant,

        [Description("Hot Food")]
        HotFood,

        [Description("First Class Meal Included")]
        FirstClassMealIncluded,

        [Description("Wheel Chair Reservations Only")]
        WheelChairOnly,

        [Description("Restaurant")]
        Restaurant,

        [Description("Trolley Service")]
        TrolleyService
    }
}
