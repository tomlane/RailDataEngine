using System.ComponentModel;

namespace RailDataEngine.Domain.Entities.Schedule.Enums
{
    public enum TransactionType
    {
        [Description("Create Record")]
        Create,

        [Description("Delete Record")]
        Delete,

        [Description("Update Record")]
        Update
    }
}