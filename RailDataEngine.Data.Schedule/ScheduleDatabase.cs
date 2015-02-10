using System;
using System.Configuration;
using RailDataEngine.Data.Common;

namespace RailDataEngine.Data.Schedule
{
    public class ScheduleDatabase : IScheduleDatabase
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        private IScheduleContext _context = null;
        private readonly string ScheduleConnectionKey = ConfigurationManager.AppSettings["ScheduleConnectionKey"];

        public IScheduleContext DbContext
        {
            get
            {
                if (_context == null)
                    _context = BuildContext();
                return _context;
            }
            set { _context = value; }
        }

        public ScheduleDatabase(IConnectionStringProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            _connectionStringProvider = provider;

            //ensure sql provider available
            var x = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public IScheduleContext BuildContext()
        {
            return new ScheduleContext(_connectionStringProvider.ConnectionString(ScheduleConnectionKey));
        }
    }
}