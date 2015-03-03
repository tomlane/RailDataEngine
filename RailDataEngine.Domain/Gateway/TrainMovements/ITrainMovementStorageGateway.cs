﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RailDataEngine.Domain.Gateway.TrainMovements
{
    public interface ITrainMovementStorageGateway<T>
    {
        void Create(List<T> entities);
        List<T> Read(); 
        List<T> Read(Expression<Func<T, bool>> criteria);
        List<T> Read(DateTime date); 
        void Destroy(List<T> entities);
    }
}
