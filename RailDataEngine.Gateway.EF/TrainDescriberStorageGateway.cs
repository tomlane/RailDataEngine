using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RailDataEngine.Data.TrainDescriber;
using RailDataEngine.Domain.Gateway;
using RailDataEngine.Domain.Gateway.TrainDescriber;

namespace RailDataEngine.Gateway.EF
{
    public class TrainDescriberStorageGateway<T> : ITrainDescriberStorageGateway<T> where T : class, IIdentifyable
    {
        private ITrainDescriberContext _context;

        public TrainDescriberStorageGateway(ITrainDescriberDatabase database)
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

        public List<T> Read()
        {
            throw new NotImplementedException();
        }

        public List<T> Read(Expression<Func<T, bool>> criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException("criteria");

            return _context.GetSet<T>().Where(criteria).ToList();
        }

        public List<T> Read(DateTime date)
        {
            throw new NotImplementedException();
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
