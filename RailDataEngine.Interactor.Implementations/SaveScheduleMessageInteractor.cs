using System;
using RailDataEngine.Domain.Interactor.SaveScheduleMessageInteractor;
using RailDataEngine.Domain.Services.ScheduleMessageConversionService;
using RailDataEngine.Domain.Services.ScheduleMessageDeserializationService;

namespace RailDataEngine.Interactor.Implementations
{
    public class SaveScheduleMessageInteractor : ISaveScheduleMessagesInteractor
    {
        public SaveScheduleMessageInteractor(IScheduleMessageDeserializationService messageDeserializationService, IScheduleMessageConversionService messageConversionService)
        {
            if (messageDeserializationService == null) throw new ArgumentNullException("messageDeserializationService");
            if (messageConversionService == null) throw new ArgumentNullException("messageConversionService");
        }

        public void SaveScheduleMessages(SaveScheduleMessageInteractorRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
