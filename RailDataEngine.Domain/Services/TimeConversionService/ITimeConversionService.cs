using System;

namespace RailDataEngine.Domain.Services.TimeConversionService
{
    public interface ITimeConversionService
    {
        DateTime? GetEpochTimeFromMilliseconds(string timeString);
        DateTime? GetEpochTimeFromSeconds(string timeString);
        DateTime? ParseDateTime(string dateTimeString);
        int? ParseRailwayMinutes(string timeString);
        bool ParseBankHolidayRunning(string runningIndicator);
    }
}
