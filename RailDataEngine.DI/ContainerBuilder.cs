using Microsoft.Practices.Unity;
using RailDataEngine.Data.Common;
using RailDataEngine.Data.Schedule;
using RailDataEngine.Gateway.Domain;
using RailDataEngine.Gateway.EF;
using RailDataEngine.Gateway.EF.Containers;

namespace RailDataEngine.DI
{
    public static class ContainerBuilder
    {
        public static IUnityContainer Build()
        {
            var container = new UnityContainer();

            container.RegisterType<IConnectionStringProvider, ConfigConnectionStringProvider>();

            container.RegisterType<IScheduleDatabase, ScheduleDatabase>();

            container.RegisterType(typeof (IStorageGateway<>), typeof (StorageGateway<>));
            
            container.RegisterType<IScheduleGatewayContainer, ScheduleGatewayContainer>();
            container.RegisterType<IMovementGatewayContainer, MovementGatewayContainer>();
            container.RegisterType<IDescriberContainer, DescriberGatewayContainer>();

            return container;
        }
    }
}