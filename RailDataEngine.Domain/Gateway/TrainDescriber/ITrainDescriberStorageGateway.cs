﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RailDataEngine.Domain.Gateway.TrainDescriber
{
    public interface ITrainDescriberStorageGateway<T>
    {
        void Create(List<T> entities);
        List<T> Read(Expression<Func<T, bool>> criteria);
        void Destroy(List<T> entities);
    }
}