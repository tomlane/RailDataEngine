namespace RailDataEngine.Domain.Services.CloudQueueService
{
    public interface ICloudQueueService
    {
        void AddToQueue(string queueName, byte[] bytes);
        void AddToQueue(string queueName, string content);
    }
}
