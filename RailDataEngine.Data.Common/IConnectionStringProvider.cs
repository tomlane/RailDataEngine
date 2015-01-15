namespace RailDataEngine.Data.Common
{
    public interface IConnectionStringProvider
    {
        string ConnectionString(string key);
    }
}
