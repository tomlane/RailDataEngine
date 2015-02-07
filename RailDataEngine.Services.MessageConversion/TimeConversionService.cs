using System;
using RailDataEngine.Domain.Services.TimeConversionService;

namespace RailDataEngine.Services.MessageConversion
{
    public class TimeConversionService : ITimeConversionService
    {
        public DateTime? GetEpochTimeFromMilliseconds(string timeString)
        {
            if (string.IsNullOrWhiteSpace(timeString))
                return null;

            long actualMilliseconds = long.Parse(timeString);

            DateTime unixTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return unixTime.AddMilliseconds(actualMilliseconds);
        }

        public DateTime? GetEpochTimeFromSeconds(string timeString)
        {
            if (string.IsNullOrWhiteSpace(timeString))
                return null;

            long actualSeconds = long.Parse(timeString);

            DateTime unixTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return unixTime.AddSeconds(actualSeconds);
        }

        public DateTime? ParseDateTime(string dateTimeString)
        {
            if (string.IsNullOrWhiteSpace(dateTimeString))
                return null;

            DateTime result;

            bool parseSuccessful = DateTime.TryParse(dateTimeString, out result);

            if (parseSuccessful)
                return result;

            return null;
        }

        public int? ParseRailwayMinutes(string timeString)
        {
            if (string.IsNullOrWhiteSpace(timeString))
                return null;

            if (timeString.Length == 1 && timeString.Contains("H"))
                return 1;

            int result = 0;

            if (timeString.Contains("H"))
            {
                timeString = timeString.Replace('H', ' ').Trim();
                result += 1;
            }

            result += int.Parse(timeString);

            return result;
        }

        public bool ParseBankHolidayRunning(string runningIndicator)
        {
            return !string.IsNullOrWhiteSpace(runningIndicator) && runningIndicator.Contains("X");
        }
    }
}
