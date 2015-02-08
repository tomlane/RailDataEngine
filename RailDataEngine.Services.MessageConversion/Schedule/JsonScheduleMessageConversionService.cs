using System;
using System.Collections.Generic;
using System.Linq;
using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Domain.Providers;
using RailDataEngine.Domain.Services.MessageValidationService;
using RailDataEngine.Domain.Services.ScheduleMessageConversionService;
using RailDataEngine.Domain.Services.ScheduleMessageDeserializationService.Entity;
using RailDataEngine.Domain.Services.TimeConversionService;
using MetaData = RailDataEngine.Domain.Entity.Schedule.MetaData;

namespace RailDataEngine.Services.MessageConversion.Schedule
{
    public class JsonScheduleMessageConversionService : IScheduleMessageConversionService
    {
        private IMessageValidationService _messageValidationService;
        private IScheduleInformationProvider _scheduleInformationProvider;
        private ITimeConversionService _timeConversionService;

        public JsonScheduleMessageConversionService(IMessageValidationService messageValidationService, IScheduleInformationProvider scheduleInformationProvider, ITimeConversionService timeConversionService)
        {
            if (messageValidationService == null) throw new ArgumentNullException("messageValidationService");
            if (scheduleInformationProvider == null) throw new ArgumentNullException("scheduleInformationProvider");
            if (timeConversionService == null) throw new ArgumentNullException("timeConversionService");

            _messageValidationService = messageValidationService;
            _scheduleInformationProvider = scheduleInformationProvider;
            _timeConversionService = timeConversionService;
        }

        public ScheduleMessageConversionResponse ConvertScheduleMessages(ScheduleMessageConversionRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var response = new ScheduleMessageConversionResponse
            {
                Associations = new List<Association>(),
                Headers = new List<Header>(),
                Records = new List<Record>(),
                Tiplocs = new List<Tiploc>()
            };

            if (request.Associations != null && request.Associations.Any())
            {
                foreach (var jsonAssociation in request.Associations)
                {
                    response.Associations.Add(ConvertAssociation(jsonAssociation));
                }    
            }

            if (request.Headers != null && request.Headers.Any())
            {
                foreach (var jsonScheduleHeader in request.Headers)
                {
                    response.Headers.Add(ConvertScheduleHeader(jsonScheduleHeader));
                }    
            }

            if (request.Records != null && request.Records.Any())
            {
                foreach (var jsonScheduleRecord in request.Records)
                {
                    response.Records.Add(ConvertScheduleRecord(jsonScheduleRecord));
                }    
            }

            if (request.Tiplocs != null && request.Tiplocs.Any())
            {
                foreach (var jsonTiploc in request.Tiplocs)
                {
                    response.Tiplocs.Add(ConvertTiploc(jsonTiploc));
                }
            }
            
            return response;
        }

        private Association ConvertAssociation(DeserializedJsonAssociation jsonAssociation)
        {
            return new Association
            {
                BaseLocationSuffix =
                    _messageValidationService.ValidateString(jsonAssociation.Association.LocationSuffix),
                Category = _scheduleInformationProvider.GetAssociationCategory(jsonAssociation.Association.Category),
                DateIndicator = _scheduleInformationProvider.GetDateIndicator(jsonAssociation.Association.DateIndicator),
                Days = _messageValidationService.ValidateString(jsonAssociation.Association.RunningDays),
                EndDate = _timeConversionService.ParseDateTime(jsonAssociation.Association.EndDate),
                Location = _messageValidationService.ValidateString(jsonAssociation.Association.Location),
                LocationSuffix = _messageValidationService.ValidateString(jsonAssociation.Association.LocationSuffix),
                MainTrainUid = _messageValidationService.ValidateString(jsonAssociation.Association.TrainUid),
                StartDate = _timeConversionService.ParseDateTime(jsonAssociation.Association.StartDate),
                StpIndicator = _scheduleInformationProvider.GetStpIndicator(jsonAssociation.Association.StpIndicator),
                TrainUid = _messageValidationService.ValidateString(jsonAssociation.Association.AssociationTrainUid),
                TransactionType =
                    _scheduleInformationProvider.GetTransactionType(jsonAssociation.Association.TransactionType)
            };
        }

        private Header ConvertScheduleHeader(DeserializedJsonScheduleHeader jsonScheduleHeader)
        {
            return new Header
            {
                Classification =
                    _messageValidationService.ValidateString(jsonScheduleHeader.ScheduleHeader.Classification),
                MetaData = new MetaData
                {
                    Sequence =
                        _messageValidationService.ValidateString(jsonScheduleHeader.ScheduleHeader.MetaData.Sequence),
                    Type = _messageValidationService.ValidateString(jsonScheduleHeader.ScheduleHeader.MetaData.Type)
                },
                Owner = _messageValidationService.ValidateString(jsonScheduleHeader.ScheduleHeader.Owner),
                Timestamp = _timeConversionService.GetEpochTimeFromSeconds(jsonScheduleHeader.ScheduleHeader.Timestamp)
            };
        }

        private Record ConvertScheduleRecord(DeserializedJsonScheduleRecord jsonScheduleRecord)
        {
            throw new NotImplementedException();
        }

        private Tiploc ConvertTiploc(DeserializedJsonTiploc jsonTiploc)
        {
            return new Tiploc
            {
                CrsCode = _messageValidationService.ValidateString(jsonTiploc.Tiploc.CrsCode),
                Description = _messageValidationService.ValidateString(jsonTiploc.Tiploc.Description),
                Nalco = _messageValidationService.ValidateString(jsonTiploc.Tiploc.Nalco),
                Stanox = _messageValidationService.ValidateString(jsonTiploc.Tiploc.Stanox),
                TiplocCode = _messageValidationService.ValidateString(jsonTiploc.Tiploc.Code),
                TpsDescription = _messageValidationService.ValidateString(jsonTiploc.Tiploc.TpsDescription),
                TransactionType = _scheduleInformationProvider.GetTransactionType(jsonTiploc.Tiploc.TransactionType)
            };
        }
    }
}
