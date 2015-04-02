using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.Schedule.Enums
{
    public enum Reservations
    {
        [Description("Compulsory")]
        Compulsory,

        [Description("Bicyle Reservations Essential")]
        BicyclesEssential,

        [Description("Recommended")]
        Recommended,

        [Description("Possible From Any Station")]
        PossibleFromAnyStation
    }
}