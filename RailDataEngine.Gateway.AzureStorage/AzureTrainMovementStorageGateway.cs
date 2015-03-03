using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RailDataEngine.Domain.Gateway;
using RailDataEngine.Domain.Gateway.TrainMovements;

namespace RailDataEngine.Gateway.AzureStorage
{
    public class AzureTrainMovementStorageGateway<T> : ITrainMovementStorageGateway<T> where T : class, IIdentifyable
    {
        public void Create(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public List<T> Read()
        {
            throw new NotImplementedException();
        }

        public List<T> Read(Expression<Func<T, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public List<T> Read(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Destroy(List<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
