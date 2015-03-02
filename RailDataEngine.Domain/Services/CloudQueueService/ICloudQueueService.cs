namespace RailDataEngine.Domain.Services.CloudQueueService
{
    public interface ICloudQueueService
    {
        void AddToServiceBusQueue(CloudQueueServiceRequest request);
        void AddToMessageQueue(CloudQueueServiceRequest request);
    }
}
