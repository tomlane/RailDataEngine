using System;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using RailDataEngine.Domain.Services.CloudQueueService;

namespace RailDataEngine.Services.Cloud
{
    public class AzureQueueService : ICloudQueueService
    {
        public void AddToQueue(string queueName, byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException("bytes");

            var queue = GetQueue(queueName);
            
            CloudQueueMessage message = new CloudQueueMessage(bytes);
            queue.AddMessage(message);
        }

        public void AddToQueue(string queueName, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException("content");

            var queue = GetQueue(queueName);

            CloudQueueMessage message = new CloudQueueMessage(content);
            queue.AddMessage(message);
        }

        private CloudQueue GetQueue(string queueName)
        {
            if (string.IsNullOrWhiteSpace(queueName))
                throw new ArgumentNullException("queueName");

            CloudStorageAccount storageAccount =
                CloudStorageAccount.Parse(ConfigurationManager.AppSettings["MessagesStorageAccount"]);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference(queueName);

            queue.CreateIfNotExists();

            return queue;
        }
    }
}
