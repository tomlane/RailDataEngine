﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RailDataEngine.Gateway.Domain
{
    public interface IStorageGateway<T>
    {
        void Create(List<T> entities);
        List<T> Read(Expression<Func<T, bool>> criteria);
        void Destroy(List<T> entities);
    }
}
