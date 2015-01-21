using System.Data.Entity.Infrastructure;
using RailDataEngine.Data.Common;

namespace RailDataEngine.Data.TrainDescriber
{
    public class TrainDescriberContextFactory : IDbContextFactory<TrainDescriberContext>
    {
        public TrainDescriberContext Create()
        {
            ITrainDescriberDatabase db = new TrainDescriberDatabase(new ConfigConnectionStringProvider());
            return db.BuildContext() as TrainDescriberContext;
        }
    }
}
