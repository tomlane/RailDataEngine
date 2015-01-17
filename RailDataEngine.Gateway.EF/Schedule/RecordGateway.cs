using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RailDataEngine.Data.Schedule;
using RailDataEngine.Gateway.Domain;
using RailDataEngine.Gateway.Entity.Schedule;

namespace RailDataEngine.Gateway.EF.Schedule
{
    public class RecordGateway : IStorageGateway<RecordEntity>
    {
        private readonly IScheduleContext _context;

        public RecordGateway(IScheduleDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException("database");

            _context = database.BuildContext();
        }

        public void Create(List<RecordEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var recordEntity in entities)
            {
                _context.GetSet<RecordEntity>().Add(recordEntity);
            }

            _context.SaveChanges();
        }

        public List<RecordEntity> Read(Expression<Func<RecordEntity, bool>> criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException("criteria");

            return _context.GetSet<RecordEntity>().Where(criteria).ToList();
        }

        public void Destroy(List<RecordEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var recordEntity in entities)
            {
                _context.GetSet<RecordEntity>().Remove(recordEntity);
            }

            _context.SaveChanges();
        }
    }
}
