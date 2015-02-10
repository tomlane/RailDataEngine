using System;
using System.Configuration;
using RailDataEngine.Data.Common;

namespace RailDataEngine.Data.TrainDescriber
{
    public class TrainDescriberDatabase : ITrainDescriberDatabase
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        private ITrainDescriberContext _context;
        private readonly string ScheduleConnectionKey = ConfigurationManager.AppSettings["TrainDescriberConnectionKey"];

        public ITrainDescriberContext DbContext
        {
            get
            {
                if (_context == null)
                    _context = BuildContext();
                return _context;
            }
            set { _context = value; }
        }

        public TrainDescriberDatabase(IConnectionStringProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            _connectionStringProvider = provider;

            //ensure sql provider available
            var x = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public ITrainDescriberContext BuildContext()
        {
            return new TrainDescriberContext(_connectionStringProvider.ConnectionString(ScheduleConnectionKey));
        }
    }
}
