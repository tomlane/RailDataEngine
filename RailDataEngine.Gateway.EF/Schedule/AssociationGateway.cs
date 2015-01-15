using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RailDataEngine.Data.Schedule;
using RailDataEngine.Gateway.Domain;
using RailDataEngine.Gateway.Entity.Schedule;

namespace RailDataEngine.Gateway.EF.Schedule
{
    public class AssociationGateway : IStorageGateway<AssociationEntity>
    {
        private IScheduleContext _context;

        public AssociationGateway(IScheduleDatabase scheduleDatabase)
        {
            if (scheduleDatabase == null)
                throw new ArgumentNullException("scheduleDatabase");

            _context = scheduleDatabase.BuildContext();
        }

        public void Create(AssociationEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _context.GetSet<AssociationEntity>().Add(entity);

            _context.SaveChanges();
        }

        public IEnumerable<AssociationEntity> Read(Expression<Func<AssociationEntity, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public void Update(AssociationEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Destroy(AssociationEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Destroy(Expression<Func<AssociationEntity, bool>> criteria)
        {
            throw new NotImplementedException();
        }
    }
}
