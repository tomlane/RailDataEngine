using System.ComponentModel;

namespace RailDataEngine.Domain.Entity.Schedule
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