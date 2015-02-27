using System;
using RailDataEngine.Domain.Boundary.Schedule.FetchServiceScheduleBoundary;
using RailDataEngine.Domain.Interactor.FetchServiceScheduleInteractor;

namespace RailDataEngine.Core.Boundary.Schedule
{
    public class FetchServiceScheduleBoundary : IFetchServiceScheduleBoundary
    {
        private readonly IFetchServiceScheduleInteractor _interactor;

        public FetchServiceScheduleBoundary(IFetchServiceScheduleInteractor interactor)
        {
            if (interactor == null)
                throw new ArgumentNullException("interactor");

            _interactor = interactor;
        }

        public FetchServiceScheduleBoundaryResponse Invoke(FetchServiceScheduleBoundaryRequest request)
        {
            var result = _interactor.FetchServiceSchedule(new FetchServiceScheduleInteractorRequest
            {
                Date = request.Date,
                TrainUid = request.TrainUid
            });

            return new FetchServiceScheduleBoundaryResponse
            {
                Record = result.Record
            };
        }
    }
}
