namespace RailDataEngine.Domain.Services.TwitterService
{
    public interface ITwitterService
    {
        void SendLateTweets(LateTrainTweetRequest request);
    }
}
