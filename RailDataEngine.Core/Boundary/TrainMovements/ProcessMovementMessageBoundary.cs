using System;
using Exceptionless;
using RailDataEngine.Domain.Boundary.TrainMovements.ProcessMovementMessageBoundary;
using RailDataEngine.Domain.Interactor.ProcessMovementMessageInteractor;

namespace RailDataEngine.Core.Boundary.TrainMovements
{
    public class ProcessMovementMessageBoundary : IProcessMovementMessageBoundary
    {
        private readonly IProcessMovementMessageInteractor _interactor;

        public ProcessMovementMessageBoundary(IProcessMovementMessageInteractor interactor)
        {
            if (interactor == null)
                throw new ArgumentNullException("interactor");

            _interactor = interactor;
        }

        public void Invoke(ProcessMovementMessageBoundaryRequest request)
        {
            try
            {
                _interactor.ProcessMovementMessages(new ProcessMovementMessageInteractorRequest
                {
                    MessageToSave = request.MessageToSave
                });
            }
            catch (Exception ex)
            {
                ex.ToExceptionless().AddObject(request).AddTags(new[]
                {
                    "Incoming message",
                    "Movement message"
                }).Submit();
            }
        }
    }
}
