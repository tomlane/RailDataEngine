using System.Collections.Generic;

namespace RailDataEngine.Domain.Services.TwitterService
{
    public class LateTrainTweetRequest
    {
        public List<LateServiceTweetInfo> LateServiceList { get; set; }
    }
}