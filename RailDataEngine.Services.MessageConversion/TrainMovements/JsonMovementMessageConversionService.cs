using System;
using System.Collections.Generic;
using System.Linq;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Providers;
using RailDataEngine.Domain.Services.MessageValidationService;
using RailDataEngine.Domain.Services.MovementMessageConversionService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService.Entity;
using RailDataEngine.Domain.Services.TimeConversionService;

namespace RailDataEngine.Services.MessageConversion.TrainMovements
{
    public class JsonMovementMessageConversionService : IMovementMessageConversionService
    {
        private readonly IMessageValidationService _messageValidationService;
        private readonly ITimeConversionService _timeConversionService;
        private readonly IMovementInformationProvider _movementInformationProvider;
        private readonly IScheduleInformationProvider _scheduleInformationProvider;

        public JsonMovementMessageConversionService(
            IMessageValidationService messageValidationService, 
            ITimeConversionService timeConversionService, 
            IMovementInformationProvider movementInformationProvider, 
            IScheduleInformationProvider scheduleInformationProvider)
        {
            if (messageValidationService == null) throw new ArgumentNullException("messageValidationService");
            if (timeConversionService == null) throw new ArgumentNullException("timeConversionService");
            if (movementInformationProvider == null) throw new ArgumentNullException("movementInformationProvider");
            if (scheduleInformationProvider == null) throw new ArgumentNullException("scheduleInformationProvider");

            _messageValidationService = messageValidationService;
            _timeConversionService = timeConversionService;
            _movementInformationProvider = movementInformationProvider;
            _scheduleInformationProvider = scheduleInformationProvider;
        }

        public MovementMessageConversionResponse ConvertMovementMessages(MovementMessageConversionRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var response = new MovementMessageConversionResponse
            {
                Activations = new List<TrainActivation>(),
                Cancellations = new List<TrainCancellation>(),
                Movements = new List<TrainMovement>()
            };

            if (request.Activations != null && request.Activations.Any())
            {
                foreach (var jsonTrainActivation in request.Activations)
                {
                    response.Activations.Add(ConvertTrainActivation(jsonTrainActivation));
                }    
            }

            if (request.Cancellations != null && request.Cancellations.Any())
            {
                foreach (var jsonTrainCancellation in request.Cancellations)
                {
                    response.Cancellations.Add(ConvertTrainCancellation(jsonTrainCancellation));
                }    
            }

            if (request.Movements != null && request.Movements.Any())
            {
                foreach (var jsonTrainMovement in request.Movements)
                {
                    response.Movements.Add(ConvertTrainMovement(jsonTrainMovement));
                }    
            }

            return response;
        }

        private TrainActivation ConvertTrainActivation(DeserializedJsonTrainActivation jsonTrainActivation)
        {
            return new TrainActivation
            {
                CallMode = _scheduleInformationProvider.GetTrainCallMode(jsonTrainActivation.Body.TrainCallMode),
                CallType = _movementInformationProvider.GetTrainCallType(jsonTrainActivation.Body.TrainCallType),
                CreationTimestamp =
                    _timeConversionService.GetEpochTimeFromMilliseconds(jsonTrainActivation.Body.CreationTimestamp),
                OriginDepartureTimestamp =
                    _timeConversionService.ParseDateTime(jsonTrainActivation.Body.OriginDepartureTimestamp),
                OriginStanox = _messageValidationService.ValidateString(jsonTrainActivation.Body.OriginStanox),
                OriginTimestamp = _timeConversionService.ParseDateTime(jsonTrainActivation.Body.OriginTimeStamp),
                ScheduleEndDate = _timeConversionService.ParseDateTime(jsonTrainActivation.Body.ScheduleEndDate),
                ScheduleOriginStanox =
                    _messageValidationService.ValidateString(jsonTrainActivation.Body.ScheduleOriginStanox),
                ScheduleSource = _scheduleInformationProvider.GetScheduleSource(jsonTrainActivation.Body.ScheduleSource),
                ScheduleStartDate = _timeConversionService.ParseDateTime(jsonTrainActivation.Body.ScheduleStartDate),
                ScheduleType = _scheduleInformationProvider.GetScheduleType(jsonTrainActivation.Body.ScheduleType),
                TrainId = _messageValidationService.ValidateString(jsonTrainActivation.Body.TrainId),
                TrainUid = _messageValidationService.ValidateString(jsonTrainActivation.Body.TrainUid)
            };
        }

        private TrainCancellation ConvertTrainCancellation(DeserializedJsonTrainCancellation jsonTrainCancellation)
        {
            return new TrainCancellation
            {
                DepartureTimestamp = _timeConversionService.GetEpochTimeFromMilliseconds(jsonTrainCancellation.Body.DepartureTimestamp),
                DivisionCode = _messageValidationService.ValidateString(jsonTrainCancellation.Body.DivisionCode),
                LocationStanox = _messageValidationService.ValidateString(jsonTrainCancellation.Body.LocationStanox),
                OriginalLocationStanox = _messageValidationService.ValidateString(jsonTrainCancellation.Body.OriginLocationStanox),
                OriginalLocationTimestamp = _timeConversionService.GetEpochTimeFromMilliseconds(jsonTrainCancellation.Body.OriginLocationTimestamp),
                ReasonCode = _messageValidationService.ValidateString(jsonTrainCancellation.Body.CancellationReasonCode),
                Timestamp = _timeConversionService.GetEpochTimeFromMilliseconds(jsonTrainCancellation.Body.CancellationTimestamp),
                TocId = _messageValidationService.ValidateString(jsonTrainCancellation.Body.TocId),
                TrainFileAdress = _messageValidationService.ValidateString(jsonTrainCancellation.Body.TrainFileAddress),
                TrainId = _messageValidationService.ValidateString(jsonTrainCancellation.Body.TrainId),
                TrainServiceCode = _messageValidationService.ValidateString(jsonTrainCancellation.Body.TrainServiceCode),
                Type = _movementInformationProvider.GetCancellationType(jsonTrainCancellation.Body.CancellationType)
            };
        }

        private TrainMovement ConvertTrainMovement(DeserializedJsonTrainMovement jsonTrainMovement)
        {
            return new TrainMovement
            {
                ActualTimestamp = _timeConversionService.GetEpochTimeFromMilliseconds(jsonTrainMovement.Body.ActualTimestamp),
                CurrentTrainId = _messageValidationService.ValidateString(jsonTrainMovement.Body.CurrentTrainId),
                Direction = _movementInformationProvider.GetTrainDirection(jsonTrainMovement.Body.Direction),
                DivisionCode = _messageValidationService.ValidateString(jsonTrainMovement.Body.DivisionCode),
                EventSource = _movementInformationProvider.GetEventSource(jsonTrainMovement.Body.EventSource),
                EventType = _movementInformationProvider.GetEventType(jsonTrainMovement.Body.EventType),
                HasTerminated = _messageValidationService.ValidateBool(jsonTrainMovement.Body.TrainTerminated),
                IsAutoExpected = _messageValidationService.ValidateBool(jsonTrainMovement.Body.AutoExpected),
                IsCorrection = _messageValidationService.ValidateBool(jsonTrainMovement.Body.Correction),
                IsDelayMonitoringPoint = _messageValidationService.ValidateBool(jsonTrainMovement.Body.DelayMonitoringPoint),
                IsOffRoute = _messageValidationService.ValidateBool(jsonTrainMovement.Body.OffRoute),
                Line = _messageValidationService.ValidateString(jsonTrainMovement.Body.Line),
                LocationStanox = _messageValidationService.ValidateString(jsonTrainMovement.Body.LocationStanox),
                NextReportRunTime = _messageValidationService.ParseInt(jsonTrainMovement.Body.NextReportRunTime),
                NextReportStanox = _messageValidationService.ValidateString(jsonTrainMovement.Body.NextReportStanox),
                OriginalLocationStanox = _messageValidationService.ValidateString(jsonTrainMovement.Body.OriginalLocationStanox),
                OriginalLocationTimestamp = _timeConversionService.GetEpochTimeFromMilliseconds(jsonTrainMovement.Body.OriginalLocationTimestamp),
                PassengerTimestamp = _timeConversionService.GetEpochTimeFromMilliseconds(jsonTrainMovement.Body.GbttTimestamp),
                PlannedEventType = _movementInformationProvider.GetEventType(jsonTrainMovement.Body.PlannedEventType),
                PlannedTimestamp = _timeConversionService.GetEpochTimeFromMilliseconds(jsonTrainMovement.Body.PlannedTimestamp),
                ReportingStanox = _messageValidationService.ValidateString(jsonTrainMovement.Body.ReportingStanox),
                Route = _messageValidationService.ValidateString(jsonTrainMovement.Body.Route),
                TimetableVariation = _messageValidationService.ParseInt(jsonTrainMovement.Body.TimetableVariation),
                TocId = _messageValidationService.ValidateString(jsonTrainMovement.Body.TocId),
                TrainFileAddress = _messageValidationService.ValidateString(jsonTrainMovement.Body.TrainFileAddress),
                TrainId = _messageValidationService.ValidateString(jsonTrainMovement.Body.TrainId),
                TrainServiceCode = _messageValidationService.ValidateString(jsonTrainMovement.Body.TrainServiceCode),
                VariationStatus = _movementInformationProvider.GetVariationStatus(jsonTrainMovement.Body.VariationStatus)
            };
        }
    }
}
