using System.Data.Entity.Infrastructure;
using RailDataEngine.Data.Common;

namespace RailDataEngine.Data.Schedule
{
    public class ScheduleContextFactory : IDbContextFactory<ScheduleContext>
    {
        public ScheduleContext Create()
        {
            IScheduleDatabase db = new ScheduleDatabase(new ConfigConnectionStringProvider());
            return db.BuildContext() as ScheduleContext;
        }
    }
}
