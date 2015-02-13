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
        private readonly IMessageValidationService _messageValidationService;
        private readonly IScheduleInformationProvider _scheduleInformationProvider;
        private readonly ITimeConversionService _timeConversionService;
        private readonly ITrainInformationProvider _trainInformationProvider;

        public JsonScheduleMessageConversionService(
            IMessageValidationService messageValidationService, 
            IScheduleInformationProvider scheduleInformationProvider, 
            ITimeConversionService timeConversionService,
            ITrainInformationProvider trainInformationProvider)
        {
            if (messageValidationService == null) throw new ArgumentNullException("messageValidationService");
            if (scheduleInformationProvider == null) throw new ArgumentNullException("scheduleInformationProvider");
            if (timeConversionService == null) throw new ArgumentNullException("timeConversionService");
            if (trainInformationProvider == null) throw new ArgumentNullException("trainInformationProvider");

            _messageValidationService = messageValidationService;
            _scheduleInformationProvider = scheduleInformationProvider;
            _timeConversionService = timeConversionService;
            _trainInformationProvider = trainInformationProvider;
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
            var record = new Record
            {
                AtocCode = _messageValidationService.ValidateString(jsonScheduleRecord.Schedule.AtocCode),
                BankHolidayRunning = _timeConversionService.ParseBankHolidayRunning(jsonScheduleRecord.Schedule.BankHolidayRunning),
                EndDate = _timeConversionService.ParseDateTime(jsonScheduleRecord.Schedule.ScheduleEndDate),
                RunningDays = _messageValidationService.ValidateString(jsonScheduleRecord.Schedule.RunDays),
                StartDate = _timeConversionService.ParseDateTime(jsonScheduleRecord.Schedule.ScheduleStartDate),
                StpIndicator = _scheduleInformationProvider.GetStpIndicator(jsonScheduleRecord.Schedule.StpIndicator),
                TrainStatus = _messageValidationService.ValidateString(jsonScheduleRecord.Schedule.TrainStatus),
                TrainUid = _messageValidationService.ValidateString(jsonScheduleRecord.Schedule.TrainUid),
                TransactionType = _scheduleInformationProvider.GetTransactionType(jsonScheduleRecord.Schedule.TransactionType)
            };

            if (jsonScheduleRecord.Schedule.ScheduleSegment != null)
            {
                record.BusinessSector = _messageValidationService.ValidateString(jsonScheduleRecord.Schedule.ScheduleSegment.BusinessSector);
                record.CateringCode = _trainInformationProvider.GetCateringCode(jsonScheduleRecord.Schedule.ScheduleSegment.CateringCode);
                record.Locations = ConvertScheduleLocations(jsonScheduleRecord.Schedule.ScheduleSegment.ScheduleLocation);
                record.OperatingCharacteristics = _messageValidationService.ValidateString(jsonScheduleRecord.Schedule.ScheduleSegment.OperatingCharateristics);
                record.PowerType = _messageValidationService.ValidateString(jsonScheduleRecord.Schedule.ScheduleSegment.PowerType);
                record.Reservations = _trainInformationProvider.GetTrainResevationDetails(jsonScheduleRecord.Schedule.ScheduleSegment.Reservations);
                record.ServiceBrand = _trainInformationProvider.GetTrainServiceBrand(jsonScheduleRecord.Schedule.ScheduleSegment.ServiceBranding);
                record.SignallingId = _messageValidationService.ValidateString(jsonScheduleRecord.Schedule.ScheduleSegment.SignallingId);
                record.Sleepers = _trainInformationProvider.GetTrainSleeperDetails(jsonScheduleRecord.Schedule.ScheduleSegment.Sleepers);
                record.Speed = _messageValidationService.ParseInt(jsonScheduleRecord.Schedule.ScheduleSegment.Speed);
                record.TimingLoad = _messageValidationService.ValidateString(jsonScheduleRecord.Schedule.ScheduleSegment.TimingLoad);
                record.TrainCategory = _messageValidationService.ValidateString(jsonScheduleRecord.Schedule.ScheduleSegment.TrainCategory);
                record.TrainClass = _trainInformationProvider.GetTrainClass(jsonScheduleRecord.Schedule.ScheduleSegment.TrainClass);
                record.TrainServiceCode = _messageValidationService.ValidateString(jsonScheduleRecord.Schedule.ScheduleSegment.TrainServiceCode);
            }
                

            if (jsonScheduleRecord.Schedule.NewScheduleSegment != null)
                record.UicCode = _messageValidationService.ValidateString(jsonScheduleRecord.Schedule.NewScheduleSegment.UicCode);

            return record;
        }

        private List<Location> ConvertScheduleLocations(DeserilaizedJsonLocation[] scheduleLocation)
        {
            var response = new List<Location>();

            if (scheduleLocation == null)
                return response;

            foreach (var jsonLocation in scheduleLocation)
            {
                response.Add(new Location
                {
                    Arrival = _messageValidationService.ValidateString(jsonLocation.Arrival),
                    Departure = _messageValidationService.ValidateString(jsonLocation.Departure),
                    EngineeringAllowance = _timeConversionService.ParseRailwayMinutes(jsonLocation.EngineeringAllowance),
                    Line = _messageValidationService.ValidateString(jsonLocation.Line),
                    LocationIdentity = _scheduleInformationProvider.GetLocationType(jsonLocation.LocationType),
                    LocationType = _scheduleInformationProvider.GetLocationType(jsonLocation.LocationType),
                    Pass = _messageValidationService.ValidateString(jsonLocation.Pass),
                    Path = _messageValidationService.ValidateString(jsonLocation.Path),
                    PathingAllowance = _timeConversionService.ParseRailwayMinutes(jsonLocation.PathingAllowance),
                    PerformanceAllowance = _timeConversionService.ParseRailwayMinutes(jsonLocation.PerformanceAllowance),
                    Platform = _messageValidationService.ValidateString(jsonLocation.Platform),
                    PublicArrival = _messageValidationService.ValidateString(jsonLocation.PublicArrival),
                    PublicDeparture = _messageValidationService.ValidateString(jsonLocation.PublicDeparture),
                    TiplocCode = _messageValidationService.ValidateString(jsonLocation.TiplocCode)
                });
            }

            return response;
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
