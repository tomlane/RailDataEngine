using System;
using System.Linq;
using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Domain.Gateway.Schedule;
using RailDataEngine.Domain.Interactor.FetchServiceScheduleInteractor;

namespace RailDataEngine.Core.Interactor.Schedule
{
    public class FetchServiceScheduleInteractor : IFetchServiceScheduleInteractor
    {
        private readonly IScheduleStorageGateway<Record> _gateway;

        public FetchServiceScheduleInteractor(IScheduleStorageGateway<Record> gateway)
        {
            if (gateway == null)
                throw new ArgumentNullException("gatewayContainer");

            _gateway = gateway;
        }

        public FetchServiceScheduleInteractorResponse FetchServiceSchedule(FetchServiceScheduleInteractorRequest request)
        {
            if (request.Date == null)
                request.Date = DateTime.UtcNow;

            return new FetchServiceScheduleInteractorResponse
            {
                Record =
                    _gateway.Read(
                        x => x.TrainUid == request.TrainUid && x.StartDate.Value <= request.Date.Value && x.EndDate.Value >= request.Date.Value)
                        .First()
            };
        }
    }
}
