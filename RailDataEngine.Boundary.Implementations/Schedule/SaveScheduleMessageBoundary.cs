using System;
using RailDataEngine.Domain.Boundary.Schedule.SaveScheduleMessageBoundary;
using RailDataEngine.Domain.Interactor.SaveScheduleMessageInteractor;

namespace RailDataEngine.Boundary.Implementations.Schedule
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
            _interactor.SaveScheduleMessages(new SaveScheduleMessageInteractorRequest
            {
                MessageToSave = request.MessageToSave
            });
        }
    }
}
