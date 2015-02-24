using System;
using System.Configuration;
using Apache.NMS;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using RailDataEngine.Domain.Services.FeedListenerService;

namespace RailDataEngine.Services.FeedListener
{
    public class StompTrainMovementListener : ITrainMovementListener
    {
        public void Listen()
        {
            IConnectionFactory factory = new NMSConnectionFactory(new Uri(ConfigurationManager.AppSettings["FeedUri"]));

            using (
                IConnection connection = factory.CreateConnection(ConfigurationManager.AppSettings["FeedUsername"],
                    ConfigurationManager.AppSettings["FeedPassword"]))
            {
                connection.ClientId = ConfigurationManager.AppSettings["FeedUsername"];
                connection.Start();

                using (ISession session = connection.CreateSession())
                {
                    IDestination movementDestination =
                        session.GetDestination(ConfigurationManager.AppSettings["MovementFeedTopic"]);
                    IMessageConsumer movementConsumer = session.CreateConsumer(movementDestination);
                    movementConsumer.Listener += OnMovementMessage;

                    Console.WriteLine("Movement message listener started.");

                    Console.ReadLine();
                    connection.Close();
                }
            }
        }

        private void OnMovementMessage(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;
            msg.Acknowledge();

            AddToQueue(msg.Text);
        }

        private void AddToQueue(string text)
        {
            CloudStorageAccount storageAccount =
                CloudStorageAccount.Parse(ConfigurationManager.AppSettings["MessagesStorageAccount"]);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference(ConfigurationManager.AppSettings["MovementMessageQueue"]);

            queue.CreateIfNotExists();

            CloudQueueMessage message = new CloudQueueMessage(text);
            queue.AddMessage(message);
        }
    }
}

