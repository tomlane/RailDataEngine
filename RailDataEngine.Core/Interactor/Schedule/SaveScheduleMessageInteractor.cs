using System;
using RailDataEngine.Domain.Interactor.SaveScheduleMessageInteractor;
using RailDataEngine.Domain.Services.ScheduleMessageConversionService;
using RailDataEngine.Domain.Services.ScheduleMessageDeserializationService;
using RailDataEngine.Domain.Services.ScheduleMessageStorageService;

namespace RailDataEngine.Core.Interactor.Schedule
{
    public class SaveScheduleMessageInteractor : ISaveScheduleMessagesInteractor
    {
        private readonly IScheduleMessageDeserializationService _messageDeserializationService;
        private readonly IScheduleMessageConversionService _messageConversionService;
        private readonly IScheduleMessageStorageService _messageStorageService;

        public SaveScheduleMessageInteractor(IScheduleMessageDeserializationService messageDeserializationService, IScheduleMessageConversionService messageConversionService, IScheduleMessageStorageService messageStorageService)
        {
            if (messageDeserializationService == null) throw new ArgumentNullException("messageDeserializationService");
            if (messageConversionService == null) throw new ArgumentNullException("messageConversionService");
            if (messageStorageService== null) throw new ArgumentNullException("messageStorageService");

            _messageDeserializationService = messageDeserializationService;
            _messageConversionService = messageConversionService;
            _messageStorageService = messageStorageService;
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

            _messageStorageService.SaveScheduleMessages(new SaveScheduleMessagesRequest
            {
                Associations = convertedMessages.Associations,
                Headers = convertedMessages.Headers,
                Records = convertedMessages.Records,
                Tiplocs = convertedMessages.Tiplocs
            });
        }
    }
}
