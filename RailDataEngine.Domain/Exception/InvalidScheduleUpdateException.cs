using System;

namespace RailDataEngine.Domain.Exception
{
    public class InvalidScheduleUpdateException : System.Exception
    {
        private DateTime IncidentTime { get; set; }
        private int CurrentScheduleVersion { get; set; }
        private int UpdateScheduleVersion { get; set; }
        private string ScheduleContents { get; set; }

        public InvalidScheduleUpdateException(int currentVersion, int updateVersion, string scheduleContents)
        {
            IncidentTime = DateTime.Now;
            CurrentScheduleVersion = currentVersion;
            UpdateScheduleVersion = updateVersion;
            ScheduleContents = scheduleContents;
        }
    }
}
