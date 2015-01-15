using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RailDataEngine.Gateway.Domain
{
    public interface IStorageGateway<T>
    {
        void Create(T entity);
        IEnumerable<T> Read(Expression<Func<T, bool>> criteria);
        void Update(T entity);
        void Destroy(T entity);
        void Destroy(Expression<Func<T, bool>> criteria);
    }
}
