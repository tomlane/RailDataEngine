using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using RailDataEngine.Domain.Gateway;

namespace RailDataEngine.Data.Common
{
    public abstract class ContextBase : DbContext, IContext
    {
        protected ContextBase(string connectionString)
            : base(connectionString)
        { }

        public IDbSet<T> GetSet<T>() where T : class, IIdentifyable
        {
            return Set<T>();
        }

        public List<dynamic> ExecuteQuery(string sql, params object[] parameters)
        {
            SqlCommand command = BuildSqlCommand();

            PrepareCommand(sql, parameters, command);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            return BuildDynamicList(ds.Tables[0]);
        }

        public object ExecuteScalar(string sql, params object[] paramaters)
        {
            SqlCommand command = BuildSqlCommand();

            PrepareCommand(sql, paramaters, command);

            return command.ExecuteScalar();
        }

        public object ExecuteStoredProcedureScalar(string procedureName, List<SqlParameter> parameters)
        {
            SqlCommand command = BuildSqlCommand();
            command.CommandText = procedureName;
            command.CommandType = CommandType.StoredProcedure;
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command.ExecuteReader();
        }

        public IDbEntityEntryWrapper WrappedEntry(object entity)
        {
            return new DbEntityEntryWrapper(this.Entry(entity));
        }

        public List<TEntity> ExecuteQuery<TEntity>(string sql, params object[] parameters)
        {
            var list = this.Database.SqlQuery<TEntity>(sql, parameters).ToList();

            return list;
        }

        public int ExecuteCommand(string sql, params object[] paramaters)
        {
            SqlCommand command = BuildSqlCommand();

            PrepareCommand(sql, paramaters, command);

            return command.ExecuteNonQuery();
        }

        private SqlCommand BuildSqlCommand()
        {
            if (this.Database.Connection.State != ConnectionState.Open)
                this.Database.Connection.Open();

            SqlCommand command = this.Database.Connection.CreateCommand() as SqlCommand;
            if (command == null)
                throw new ArgumentException("SqlCommand not created from connection");
            return command;
        }

        private void PrepareCommand(string sql, object[] paramaters, SqlCommand command)
        {
            Dictionary<string, object> queryParameters = new Dictionary<string, object>();
            for (int i = 0; i < paramaters.Length; i++)
            {
                queryParameters.Add("@param" + i.ToString(), paramaters[i]);
            }
            sql = string.Format(sql, queryParameters.Keys.ToArray());

            command.CommandText = sql;
            foreach (var parameter in queryParameters)
            {
                command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
            }
        }

        private List<dynamic> BuildDynamicList(DataTable table)
        {
            List<dynamic> list = new List<dynamic>();
            foreach (DataRow row in table.Rows)
            {
                dynamic expando = new ExpandoObject();
                var dictionary = expando as IDictionary<String, object>;
                foreach (DataColumn column in table.Columns)
                {
                    dictionary.Add(column.ColumnName, row[column.ColumnName]);
                }
                list.Add(expando);
            }
            return list;
        }
    }
}
