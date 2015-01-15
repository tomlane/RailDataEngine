using System.Configuration;

namespace RailDataEngine.Data.Common
{
    public class ConfigConnectionStringProvider : IConnectionStringProvider
    {
        public string ConnectionString(string key)
        {
            if (ConfigurationManager.ConnectionStrings[key] == null)
                throw new ConfigurationErrorsException
                    (string.Format("Connection string with key '{0}' not defined in configuration file", key));

            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
    }
}
