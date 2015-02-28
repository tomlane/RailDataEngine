using System;

namespace RailDataEngine.Domain.Services.TwitterService
{
    public class LateServiceTweetInfo
    {
        public string TrainId { get; set; }
        public bool IsCorrection { get; set; }
        public int Delay { get; set; }
        public DateTime PassengerTimestamp { get; set; }
        public string Stanox { get; set; }
    }
}