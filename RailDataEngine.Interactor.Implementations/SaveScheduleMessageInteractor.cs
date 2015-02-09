using System;
using RailDataEngine.Domain.Interactor.SaveScheduleMessageInteractor;
using RailDataEngine.Domain.Services.ScheduleMessageConversionService;
using RailDataEngine.Domain.Services.ScheduleMessageDeserializationService;

namespace RailDataEngine.Interactor.Implementations
{
    public class SaveScheduleMessageInteractor : ISaveScheduleMessagesInteractor
    {
        private readonly IScheduleMessageDeserializationService _messageDeserializationService;
        private readonly IScheduleMessageConversionService _messageConversionService;

        public SaveScheduleMessageInteractor(IScheduleMessageDeserializationService messageDeserializationService, IScheduleMessageConversionService messageConversionService)
        {
            if (messageDeserializationService == null) throw new ArgumentNullException("messageDeserializationService");
            if (messageConversionService == null) throw new ArgumentNullException("messageConversionService");

            _messageDeserializationService = messageDeserializationService;
            _messageConversionService = messageConversionService;
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
        }
    }
}
