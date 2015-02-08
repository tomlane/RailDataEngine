using Microsoft.Practices.Unity;
using RailDataEngine.Boundary.Implementations.StationBoard;
using RailDataEngine.Boundary.Implementations.TrainMovements;
using RailDataEngine.Data.Common;
using RailDataEngine.Data.Schedule;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardArrivalsBoundary;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardDeparturesBoundary;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardServiceDetailsBoundary;
using RailDataEngine.Domain.Boundary.TrainMovements.SaveMovementMessageBoundary;
using RailDataEngine.Domain.Gateway;
using RailDataEngine.Domain.Interactor.StationBoardInteractor;
using RailDataEngine.Domain.Providers;
using RailDataEngine.Domain.Services.FeedListener;
using RailDataEngine.Domain.Services.MessageValidationService;
using RailDataEngine.Domain.Services.MovementMessageConversionService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService;
using RailDataEngine.Domain.Services.ScheduleMessageConversionService;
using RailDataEngine.Domain.Services.ScheduleMessageDeserializationService;
using RailDataEngine.Domain.Services.StationBoardService;
using RailDataEngine.Domain.Services.TimeConversionService;
using RailDataEngine.Gateway.EF;
using RailDataEngine.Gateway.EF.Containers;
using RailDataEngine.Interactor.Implementations;
using RailDataEngine.Services.DarwinStationBoard;
using RailDataEngine.Services.DarwinStationBoard.DarwinServiceReference;
using RailDataEngine.Services.FeedListener;
using RailDataEngine.Services.MessageConversion;
using RailDataEngine.Services.MessageConversion.Providers;
using RailDataEngine.Services.MessageConversion.Schedule;
using RailDataEngine.Services.MessageConversion.TrainMovements;

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
            container.RegisterType<ISaveMovementMessageBoundary, SaveMovementMessageBoundary>();

            container.RegisterType<ITrainMovementListener, StompTrainMovementListener>();

            container.RegisterType<IMovementMessageDeserializationService, JsonMovementMessageDeserializationService>();
            container.RegisterType<IMovementMessageConversionService, JsonMovementMessageConversionService>();
            container.RegisterType<IScheduleMessageDeserializationService, JsonScheduleMessageDeserializationService>();
            container.RegisterType<IScheduleMessageConversionService, JsonScheduleMessageConversionService>();
            container.RegisterType<IMessageValidationService, MessageValidationService>();
            container.RegisterType<ITimeConversionService, TimeConversionService>();

            container.RegisterType<IMovementInformationProvider, MovementInformationProvider>();
            container.RegisterType<IScheduleInformationProvider, ScheduleInformationProvider>();
            container.RegisterType<ITrainInformationProvider, TrainInformationProvider>();

            return container;
        }
    }
}