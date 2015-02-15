using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;
using RailDataEngine.Data.Schedule;
using RailDataEngine.Domain.Gateway;
using RailDataEngine.Domain.Gateway.Schedule;

namespace RailDataEngine.Gateway.EF
{
    public class ScheduleStorageGateway<T> : IScheduleStorageGateway<T> where T : class, IIdentifyable
    {
        private readonly ScheduleContext _context;
        
        public ScheduleStorageGateway(IScheduleDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException("database");

            _context = database.BuildContext() as ScheduleContext;
        }

        public void Create(List<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            _context.Set<T>().AddRange(entities);

            _context.SaveChanges();
        }

        public List<T> Read(Expression<Func<T, bool>> criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException("criteria");

            return _context.GetSet<T>().Where(criteria).ToList();
        }

        public void Destroy(Expression<Func<T, bool>> criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException("criteria");

            var entites = _context.GetSet<T>().Where(criteria).ToList();

            if (!entites.Any()) 
                throw new EntityException("No entites found to delete");
            
            foreach (var entity in entites)
            {
                _context.GetSet<T>().Remove(entity);
            }

            _context.SaveChanges();
        }
    }
}
