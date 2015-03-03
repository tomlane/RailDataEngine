namespace RailDataEngine.Domain.Services.CloudQueueService
{
    public class CloudQueueServiceRequest
    {
        public string MessageContent { get; set; }
        public string QueueName { get; set; }
    }
}
