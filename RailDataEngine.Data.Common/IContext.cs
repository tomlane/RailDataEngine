using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using RailDataEngine.Domain.Gateway;

namespace RailDataEngine.Data.Common
{
    public interface IContext
    {
        IDbSet<T> GetSet<T>() where T : class, IIdentifyable;

        List<dynamic> ExecuteQuery(string sql, params object[] parameters);
        object ExecuteScalar(string sql, params object[] paramaters);
        List<TEntity> ExecuteQuery<TEntity>(string sql, params object[] parameters);
        int ExecuteCommand(string sql, params object[] parameters);
        object ExecuteStoredProcedureScalar(string sql, List<SqlParameter> paramaters);

        IDbEntityEntryWrapper WrappedEntry(object entity);

        //implemented in DbContext - for all intense and purposes this is the UOW interface
        int SaveChanges();
    }
}
