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
        public void AddToQueue(string queueName, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException("content");

            var queue = GetQueue(queueName);

            CloudQueueMessage message = new CloudQueueMessage(content);
            queue.AddMessage(message);
        }

        public void AddToMessageBusQueue(string queueName, string content)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ServiceBus"].ConnectionString;

            CheckServiceBusQueueExists(connectionString);

            TopicClient client = TopicClient.CreateFromConnectionString(connectionString, "realtimeraildata");

            client.Send(new BrokeredMessage(content));
        }

        private static void CheckServiceBusQueueExists(string connectionString)
        {
            TopicDescription topicDescription = new TopicDescription("realtimeraildata")
            {
                MaxSizeInMegabytes = 5120,
                DefaultMessageTimeToLive = TimeSpan.FromSeconds(30)
            };

            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            if (!namespaceManager.TopicExists("realtimeraildata"))
            {
                namespaceManager.CreateTopic(topicDescription);
            }

            if (!namespaceManager.SubscriptionExists("realtimeraildata", "AllMessages"))
            {
                namespaceManager.CreateSubscription("realtimeraildata", "AllMessages");
            }
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
