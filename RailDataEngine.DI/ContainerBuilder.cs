using Microsoft.Practices.Unity;
using RailDataEngine.Boundary.Implementations.StationBoard;
using RailDataEngine.Boundary.StationBoard.StationBoardArrivalsBoundary;
using RailDataEngine.Boundary.StationBoard.StationBoardDeparturesBoundary;
using RailDataEngine.Boundary.StationBoard.StationBoardServiceDetailsBoundary;
using RailDataEngine.Data.Common;
using RailDataEngine.Data.Schedule;
using RailDataEngine.Gateway.Domain;
using RailDataEngine.Gateway.EF;
using RailDataEngine.Gateway.EF.Containers;
using RailDataEngine.Interactor.Implementations;
using RailDataEngine.Interactor.StationBoardInteractor;
using RailDataEngine.Services.DarwinStationBoard;
using RailDataEngine.Services.DarwinStationBoard.DarwinServiceReference;
using RailDataEngine.Services.StationBoardService;

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
            container.RegisterType<ITrainMovementGatewayContainer, TrainMovementGatewayContainer>();
            container.RegisterType<ITrainDescriberContainer, TrainDescriberGatewayContainer>();

            container.RegisterType<IStationBoardService, DarwinBoardService>();
            container.RegisterType<LDBServiceSoap, LDBServiceSoapClient>(new InjectionConstructor());

            container.RegisterType<IStationBoardInteractor, StationBoardInteractor>();

            container.RegisterType<IStationBoardArrivalsBoundary, StationBoardArrivalsBoundary>();
            container.RegisterType<IStationBoardDeparturesBoundary, StationBoardDeparturesBoundary>();
            container.RegisterType<IStationBoardServiceDetailsBoundary, StationBoardServiceDetailsBoundary>();

            return container;
        }
    }
}