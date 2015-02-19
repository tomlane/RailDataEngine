using System;
using System.Collections.Generic;
using System.Linq;
using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Domain.Gateway.Schedule;
using RailDataEngine.Domain.Services.ScheduleMessageStorageService;

namespace RailDataEngine.Services.MessageStorage
{
    public class ScheduleMessageStorageService : IScheduleMessageStorageService
    {
        private readonly IScheduleGatewayContainer _scheduleGatewayContainer;

        public ScheduleMessageStorageService(IScheduleGatewayContainer scheduleGatewayContainer)
        {
            if (scheduleGatewayContainer == null)
                throw new ArgumentNullException("scheduleGatewayContainer");

            _scheduleGatewayContainer = scheduleGatewayContainer;
        }

        public void SaveScheduleMessages(SaveScheduleMessagesRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (request.Associations != null && request.Associations.Any())
                SaveAssociations(request.Associations);

            if (request.Headers != null && request.Headers.Any())
                SaveHeaders(request.Headers);

            if (request.Records != null && request.Records.Any())
                SaveRecords(request.Records);

            if (request.Tiplocs != null && request.Tiplocs.Any())
                SaveTiplocs(request.Tiplocs);
        }

        private void SaveAssociations(List<Association> associations)
        {
            _scheduleGatewayContainer.AssociationGateway.Create(associations);
        }

        private void SaveHeaders(List<Header> headers)
        {
            _scheduleGatewayContainer.HeaderGateway.Create(headers);
        }

        private void SaveRecords(List<Record> records)
        {
            foreach (var record in records)
            {
                switch (record.TransactionType)
                {
                    case TransactionType.Delete:
                        _scheduleGatewayContainer.RecordGateway.Destroy(x => x.StartDate == record.StartDate && x.TrainUid == record.TrainUid && x.StpIndicator == record.StpIndicator);
                        break;
                    default:
                        _scheduleGatewayContainer.RecordGateway.Create(new List<Record>
                        {
                            record
                        });
                        break;
                }
            }
        }

        private void SaveTiplocs(List<Tiploc> tiplocs)
        {
            foreach (var tiploc in tiplocs)
            {
                switch (tiploc.TransactionType)
                {
                    case TransactionType.Delete:
                        _scheduleGatewayContainer.TiplocGateway.Destroy(x => x.TiplocCode == tiploc.TiplocCode);
                        break;
                    default:
                        _scheduleGatewayContainer.TiplocGateway.Create(new List<Tiploc>
                        {
                            tiploc
                        });
                        break;
                }
            }
        }
    }
}
