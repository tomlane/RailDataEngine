using Microsoft.Practices.Unity;
using RailDataEngine.Data.Common;
using RailDataEngine.Data.Schedule;
using RailDataEngine.Gateway.Domain;
using RailDataEngine.Gateway.EF.Schedule;
using RailDataEngine.Gateway.Entity.Schedule;

namespace RailDataEngine.Root
{
    public static class ContainerBuilder
    {
        public static IUnityContainer Build()
        {
            var container = new UnityContainer();

            container.RegisterType<IConnectionStringProvider, ConfigConnectionStringProvider>();

            container.RegisterType<IScheduleDatabase, ScheduleDatabase>();

            container.RegisterType<IStorageGateway<AssociationEntity>, AssociationGateway>();
            container.RegisterType<IStorageGateway<HeaderEntity>, HeaderGateway>();
            container.RegisterType<IStorageGateway<LocationEntity>, LocationGateway>();
            container.RegisterType<IStorageGateway<RecordEntity>, RecordGateway>();

            return container;
        }
    }
}