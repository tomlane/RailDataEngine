using System.Data.Entity;

namespace RailDataEngine.Data.Common
{
    public interface IDbEntityEntryWrapper
    {
        EntityState State { get; set; }
    }
}
