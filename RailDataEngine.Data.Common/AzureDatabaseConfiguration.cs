using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace RailDataEngine.Data.Common
{
    public class AzureDatabaseConfiguration : DbConfiguration
    {
        public AzureDatabaseConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy(3, TimeSpan.FromSeconds(30)));
        }
    }
}
