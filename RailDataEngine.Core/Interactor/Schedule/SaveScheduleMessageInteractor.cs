using System;
using RailDataEngine.Domain.Gateway.Schedule;
using RailDataEngine.Domain.Interactor.SaveScheduleMessageInteractor;
using RailDataEngine.Domain.Services.ScheduleMessageConversionService;
using RailDataEngine.Domain.Services.ScheduleMessageDeserializationService;

namespace RailDataEngine.Core.Interactor.Schedule
{
    public class SaveScheduleMessageInteractor : ISaveScheduleMessagesInteractor
    {
        private readonly IScheduleMessageDeserializationService _messageDeserializationService;
        private readonly IScheduleMessageConversionService _messageConversionService;
        private readonly IScheduleGatewayContainer _scheduleGatewayContainer;

        public SaveScheduleMessageInteractor(IScheduleMessageDeserializationService messageDeserializationService, IScheduleMessageConversionService messageConversionService, IScheduleGatewayContainer scheduleGatewayContainer)
        {
            if (messageDeserializationService == null) throw new ArgumentNullException("messageDeserializationService");
            if (messageConversionService == null) throw new ArgumentNullException("messageConversionService");
            if (scheduleGatewayContainer == null) throw new ArgumentNullException("scheduleGatewayContainer");

            _messageDeserializationService = messageDeserializationService;
            _messageConversionService = messageConversionService;
            _scheduleGatewayContainer = scheduleGatewayContainer;
        }

        public void SaveScheduleMessages(SaveScheduleMessageInteractorRequest request)
        {
            if (request == null || request.MessagesToSave == null) 
                throw new ArgumentNullException("request");

            var deserializedMessages =
                _messageDeserializationService.DeserializeScheduleMessages(new ScheduleMessageDeserializationRequest
                {
                    MessagesToDeserialize = request.MessagesToSave
                });

            var convertedMessages =
                _messageConversionService.ConvertScheduleMessages(new ScheduleMessageConversionRequest
                {
                    Associations = deserializedMessages.Associations,
                    Headers = deserializedMessages.Headers,
                    Records = deserializedMessages.Records,
                    Tiplocs = deserializedMessages.Tiplocs
                });

            throw new NotImplementedException();
        }
    }
}
