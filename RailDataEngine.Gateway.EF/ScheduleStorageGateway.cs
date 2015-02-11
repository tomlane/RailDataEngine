using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RailDataEngine.Data.Schedule;
using RailDataEngine.Domain.Gateway;
using RailDataEngine.Domain.Gateway.Schedule;

namespace RailDataEngine.Gateway.EF
{
    public class ScheduleStorageGateway<T> : IScheduleStorageGateway<T> where T : class, IIdentifyable
    {
        private readonly IScheduleDatabase _database;

        private ScheduleContext _context;
        private ScheduleContext Context
        {
            get
            {
                if (_context == null)
                    return _database.BuildContext() as ScheduleContext;

                return _context;
            }
            set { _context = value; }
        }

        public ScheduleStorageGateway(IScheduleDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException("database");

            _database = database;
            _context = database.BuildContext() as ScheduleContext;
        }

        public void Create(List<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            _context.Set<T>().AddRange(entities);

            _context.SaveChanges();

            ResetContext();
        }

        private void ResetContext()
        {
            _context.Dispose();
            _context = _database.BuildContext() as ScheduleContext;
        }

        public List<T> Read(Expression<Func<T, bool>> criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException("criteria");

            return _context.GetSet<T>().Where(criteria).ToList();
        }

        public void Destroy(List<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var entity in entities)
            {
                _context.GetSet<T>().Remove(entity);
            }

            _context.SaveChanges();
        }
    }
}
