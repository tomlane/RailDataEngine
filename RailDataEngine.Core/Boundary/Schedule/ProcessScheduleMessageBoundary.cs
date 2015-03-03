using System;
using Exceptionless;
using RailDataEngine.Domain.Boundary.Schedule.ProcessScheduleMessageBoundary;
using RailDataEngine.Domain.Interactor.ProcessScheduleMessageInteractor;

namespace RailDataEngine.Core.Boundary.Schedule
{
    public class ProcessScheduleMessageBoundary : IProcessScheduleMessageBoundary
    {
        private readonly IProcessScheduleMessageInteractor _interactor;

        public ProcessScheduleMessageBoundary(IProcessScheduleMessageInteractor interactor)
        {
            if (interactor == null) throw new ArgumentNullException("interactor");
            _interactor = interactor;
        }

        public void Invoke(ProcessScheduleBoundaryRequest request)
        {
            try
            {
                _interactor.ProcessScheduleMessages(new ProcessScheduleMessageInteractorRequest
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
