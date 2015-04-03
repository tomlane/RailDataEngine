using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RailDataEngine.Domain.Gateways.Schedule
{
    public interface IScheduleStorageGateway<T>
    {
        void Create(List<T> entities);
        List<T> Read(Expression<Func<T, bool>> criteria);
        void Destroy(Expression<Func<T, bool>> criteria);
        int GetScheduleVersion();
    }
}
