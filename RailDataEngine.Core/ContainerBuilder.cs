using Microsoft.Practices.Unity;
using RailDataEngine.Core.Boundary.Schedule;
using RailDataEngine.Core.Boundary.StationBoard;
using RailDataEngine.Core.Boundary.TrainMovements;
using RailDataEngine.Core.Interactor.Schedule;
using RailDataEngine.Core.Interactor.StationBoard;
using RailDataEngine.Core.Interactor.TrainMovements;
using RailDataEngine.Data.Common;
using RailDataEngine.Data.Schedule;
using RailDataEngine.Data.TrainDescriber;
using RailDataEngine.Data.TrainMovements;
using RailDataEngine.Domain.Boundary.Schedule.FetchScheduleMessageBoundary;
using RailDataEngine.Domain.Boundary.Schedule.SaveScheduleMessageBoundary;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardArrivalsBoundary;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardDeparturesBoundary;
using RailDataEngine.Domain.Boundary.StationBoard.StationBoardServiceDetailsBoundary;
using RailDataEngine.Domain.Boundary.TrainMovements.SaveMovementMessageBoundary;
using RailDataEngine.Domain.Gateway.Schedule;
using RailDataEngine.Domain.Gateway.TrainDescriber;
using RailDataEngine.Domain.Gateway.TrainMovements;
using RailDataEngine.Domain.Interactor.SaveMovementMessageInteractor;
using RailDataEngine.Domain.Interactor.SaveScheduleMessageInteractor;
using RailDataEngine.Domain.Interactor.StationBoardInteractor;
using RailDataEngine.Domain.Providers;
using RailDataEngine.Domain.Services.FeedListenerService;
using RailDataEngine.Domain.Services.MessageValidationService;
using RailDataEngine.Domain.Services.MovementMessageConversionService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService;
using RailDataEngine.Domain.Services.MovementMessageStorageService;
using RailDataEngine.Domain.Services.ScheduleMessageConversionService;
using RailDataEngine.Domain.Services.ScheduleMessageDeserializationService;
using RailDataEngine.Domain.Services.ScheduleMessageStorageService;
using RailDataEngine.Domain.Services.StationBoardService;
using RailDataEngine.Domain.Services.TimeConversionService;
using RailDataEngine.Gateway.EF;
using RailDataEngine.Gateway.EF.Containers;
using RailDataEngine.Services.DarwinStationBoard;
using RailDataEngine.Services.DarwinStationBoard.DarwinServiceReference;
using RailDataEngine.Services.FeedListener;
using RailDataEngine.Services.MessageConversion;
using RailDataEngine.Services.MessageConversion.Providers;
using RailDataEngine.Services.MessageConversion.Schedule;
using RailDataEngine.Services.MessageConversion.TrainMovements;
using RailDataEngine.Services.MessageStorage;

namespace RailDataEngine.Core
{
    public static class ContainerBuilder
    {
        public static IUnityContainer Build()
        {
            var container = new UnityContainer();

            container.RegisterType<IConnectionStringProvider, ConfigConnectionStringProvider>();

            container.RegisterType<IScheduleDatabase, ScheduleDatabase>();
            container.RegisterType<ITrainMovementDatabase, TrainMovementDatabase>();
            container.RegisterType<ITrainDescriberDatabase, TrainDescriberDatabase>();

            container.RegisterType(typeof (IScheduleStorageGateway<>), typeof (ScheduleStorageGateway<>));
            container.RegisterType(typeof (ITrainMovementStorageGateway<>), typeof (TrainMovementStorageGateway<>));
            container.RegisterType(typeof (ITrainDescriberStorageGateway<>), typeof (TrainDescriberStorageGateway<>));
            
            container.RegisterType<IScheduleGatewayContainer, ScheduleGatewayContainer>();
            container.RegisterType<ITrainMovementGatewayContainer, TrainMovementGatewayContainer>();
            container.RegisterType<ITrainDescriberGatewayContainer, TrainDescriberGatewayContainer>();

            container.RegisterType<IStationBoardService, DarwinBoardService>();
            container.RegisterType<LDBServiceSoap, LDBServiceSoapClient>(new InjectionConstructor());

            container.RegisterType<IStationBoardInteractor, StationBoardInteractor>();
            container.RegisterType<ISaveMovementMessageInteractor, SaveMovementMessageInteractor>();
            container.RegisterType<ISaveScheduleMessagesInteractor, SaveScheduleMessageInteractor>();

            container.RegisterType<IStationBoardArrivalsBoundary, StationBoardArrivalsBoundary>();
            container.RegisterType<IStationBoardDeparturesBoundary, StationBoardDeparturesBoundary>();
            container.RegisterType<IStationBoardServiceDetailsBoundary, StationBoardServiceDetailsBoundary>();
            container.RegisterType<ISaveMovementMessageBoundary, SaveMovementMessageBoundary>();
            container.RegisterType<ISaveScheduleMessagesBoundary, SaveScheduleMessageBoundary>();

            container.RegisterType<ITrainMovementListener, StompTrainMovementListener>();

            container.RegisterType<IMovementMessageDeserializationService, JsonMovementMessageDeserializationService>();
            container.RegisterType<IMovementMessageConversionService, JsonMovementMessageConversionService>();
            container.RegisterType<IScheduleMessageDeserializationService, JsonScheduleMessageDeserializationService>();
            container.RegisterType<IScheduleMessageConversionService, JsonScheduleMessageConversionService>();
            container.RegisterType<IMessageValidationService, MessageValidationService>();
            container.RegisterType<ITimeConversionService, TimeConversionService>();
            container.RegisterType<IScheduleMessageStorageService, ScheduleMessageStorageService>();
            container.RegisterType<IMovementMessageStorageService, MovementMessageStorageService>();

            container.RegisterType<IMovementInformationProvider, MovementInformationProvider>();
            container.RegisterType<IScheduleInformationProvider, ScheduleInformationProvider>();
            container.RegisterType<ITrainInformationProvider, TrainInformationProvider>();

            return container;
        }
    }
}