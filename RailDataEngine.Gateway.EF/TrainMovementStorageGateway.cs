using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RailDataEngine.Data.TrainMovements;
using RailDataEngine.Domain.Gateway;
using RailDataEngine.Domain.Gateway.TrainMovements;

namespace RailDataEngine.Gateway.EF
{
    public class TrainMovementStorageGateway<T> : ITrainMovementStorageGateway<T> where T : class, IIdentifyable
    {
        private readonly ITrainMovementContext _context;

        public TrainMovementStorageGateway(ITrainMovementDatabase database)
        {
            if (database == null) throw new ArgumentNullException("database");
            _context = database.BuildContext();
        }

        public void Create(List<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var entity in entities)
            {
                _context.GetSet<T>().Add(entity);
            }

            _context.SaveChanges();
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
