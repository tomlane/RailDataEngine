using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RailDataEngine.Data.Schedule;
using RailDataEngine.Gateway.Domain;
using RailDataEngine.Gateway.Entity.Schedule;

namespace RailDataEngine.Gateway.EF.Schedule
{
    public class LocationGateway : IStorageGateway<LocationEntity>
    {
        private readonly IScheduleContext _context;

        public LocationGateway(IScheduleDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException("database");

            _context = database.BuildContext();
        }

        public void Create(List<LocationEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var locationEntity in entities)
            {
                _context.GetSet<LocationEntity>().Add(locationEntity);
            }

            _context.SaveChanges();
        }

        public List<LocationEntity> Read(Expression<Func<LocationEntity, bool>> criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException("criteria");

            return _context.GetSet<LocationEntity>().Where(criteria).ToList();
        }

        public void Destroy(List<LocationEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var locationEntity in entities)
            {
                _context.GetSet<LocationEntity>().Remove(locationEntity);
            }

            _context.SaveChanges();
        }
    }
}
