using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RailDataEngine.Data.Schedule;
using RailDataEngine.Gateway.Domain;
using RailDataEngine.Gateway.Entity.Schedule;

namespace RailDataEngine.Gateway.EF.Schedule
{
    public class AssociationGateway : IStorageGateway<AssociationEntity>
    {
        private readonly IScheduleContext _context;

        public AssociationGateway(IScheduleDatabase scheduleDatabase)
        {
            if (scheduleDatabase == null)
                throw new ArgumentNullException("scheduleDatabase");

            _context = scheduleDatabase.BuildContext();
        }

        public void Create(List<AssociationEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var associationEntity in entities)
            {
                _context.GetSet<AssociationEntity>().Add(associationEntity);    
            }

            _context.SaveChanges();
        }

        public List<AssociationEntity> Read(Expression<Func<AssociationEntity, bool>> criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException("criteria");

            return _context.GetSet<AssociationEntity>().Where(criteria).ToList();
        }

        public void Destroy(List<AssociationEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var associationEntity in entities)
            {
                _context.GetSet<AssociationEntity>().Remove(associationEntity);
            }

            _context.SaveChanges();
        }
    }
}
