using System;
using RailDataEngine.Data.Common;

namespace RailDataEngine.Data.TrainDescriber
{
    public class TrainDescriberDatabase : ITrainDescriberDatabase
    {
        private IConnectionStringProvider _connectionStringProvider;

        private ITrainDescriberContext _context = null;
        private const string ScheduleConnectionKey = "test";

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
