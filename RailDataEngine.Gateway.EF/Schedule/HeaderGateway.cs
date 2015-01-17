using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RailDataEngine.Data.Schedule;
using RailDataEngine.Gateway.Domain;
using RailDataEngine.Gateway.Entity.Schedule;

namespace RailDataEngine.Gateway.EF.Schedule
{
    public class HeaderGateway : IStorageGateway<HeaderEntity>
    {
        private readonly IScheduleContext _context;

        public HeaderGateway(IScheduleDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException("database");

            _context = database.BuildContext();
        }

        public void Create(List<HeaderEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var headerEntity in entities)
            {
                _context.GetSet<HeaderEntity>().Add(headerEntity);
            }

            _context.SaveChanges();
        }

        public List<HeaderEntity> Read(Expression<Func<HeaderEntity, bool>> criteria)
        {
            if (criteria == null) 
                throw new ArgumentNullException("criteria");

            return _context.GetSet<HeaderEntity>().Where(criteria).ToList();
        }

        public void Destroy(List<HeaderEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var headerEntity in entities)
            {
                _context.GetSet<HeaderEntity>().Remove(headerEntity);
            }

            _context.SaveChanges();
        }
    }
}
