using System;
using System.Configuration;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using RailDataEngine.Domain.Services.CloudQueueService;

namespace RailDataEngine.Services.Cloud
{
    public class AzureQueueService : ICloudQueueService
    {
        public void AddToServiceBusQueue(CloudQueueServiceRequest request)
        {
            throw new NotImplementedException();
        }

        public void AddToMessageQueue(CloudQueueServiceRequest request)
        {
            throw new NotImplementedException();
        }

        private static void ValidateServiceBusQueue(string connectionString, string queueName)
        {
            QueueDescription queueDescription = new QueueDescription(queueName)
            {
                MaxSizeInMegabytes = 5120,
                DefaultMessageTimeToLive = TimeSpan.FromSeconds(30)
            };

            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            if (!namespaceManager.QueueExists(queueName))
            {
                namespaceManager.CreateQueue(queueDescription);
            }
        }

        private CloudQueue ValidateStorageMessageQueue(string queueName)
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
