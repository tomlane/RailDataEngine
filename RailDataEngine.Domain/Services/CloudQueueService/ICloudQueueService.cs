namespace RailDataEngine.Domain.Services.CloudQueueService
{
    public interface ICloudQueueService
    {
        void AddToQueue(string queueName, string content);
        void AddToMessageBusQueue(string queueName, string content);
    }
}
