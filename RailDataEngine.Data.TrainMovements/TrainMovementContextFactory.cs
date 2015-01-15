using System.Data.Entity.Infrastructure;
using RailDataEngine.Data.Common;

namespace RailDataEngine.Data.TrainMovements
{
    public class TrainMovementContextFactory : IDbContextFactory<TrainMovementContext>
    {
        public TrainMovementContext Create()
        {
            ITrainMovementDatabase db = new TrainMovementDatabase(new ConfigConnectionStringProvider());
            return db.BuildContext() as TrainMovementContext;
        }
    }
}
