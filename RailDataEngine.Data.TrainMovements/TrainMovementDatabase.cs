using System;
using RailDataEngine.Data.Common;

namespace RailDataEngine.Data.TrainMovements
{
	public class TrainMovementDatabase : ITrainMovementDatabase
	{
		private IConnectionStringProvider _connectionStringProvider;

		private ITrainMovementContext _context = null;
		private const string TrainMovementConnectionKey = "test";

		public ITrainMovementContext DbContext
		{
			get
			{
				if (_context == null)
					_context = BuildContext();
				return _context;
			}
			set { _context = value; }
		}

		public TrainMovementDatabase(IConnectionStringProvider provider)
		{
			if (provider == null)
				throw new ArgumentNullException("provider");

			_connectionStringProvider = provider;

			//ensure sql provider available
			var x = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
		}

		public ITrainMovementContext BuildContext()
		{
			return new TrainMovementContext(_connectionStringProvider.ConnectionString(TrainMovementConnectionKey));
		}
	}
}
