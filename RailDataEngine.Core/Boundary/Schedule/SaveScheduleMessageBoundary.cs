using System;
using Exceptionless;
using RailDataEngine.Domain.Boundary.Schedule.SaveScheduleMessageBoundary;
using RailDataEngine.Domain.Interactor.SaveScheduleMessageInteractor;

namespace RailDataEngine.Core.Boundary.Schedule
{
    public class SaveScheduleMessageBoundary : ISaveScheduleMessagesBoundary
    {
        private readonly ISaveScheduleMessagesInteractor _interactor;

        public SaveScheduleMessageBoundary(ISaveScheduleMessagesInteractor interactor)
        {
            if (interactor == null) throw new ArgumentNullException("interactor");
            _interactor = interactor;
        }

        public void Invoke(SaveScheduleBoundaryRequest request)
        {
            try
            {
                _interactor.SaveScheduleMessages(new SaveScheduleMessageInteractorRequest
                {
                    MessagesToSave = request.MessagesToSave
                });
            }
            catch (Exception ex)
            {
                ex.ToExceptionless().AddObject(request).AddTags(new[]
                {
                    "Incoming message",
                    "Schedule message"
                }).Submit();
            }
        }
    }
}
