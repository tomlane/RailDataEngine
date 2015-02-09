using System;
using System.Configuration;
using Apache.NMS;
using RailDataEngine.Domain.Boundary.TrainMovements.SaveMovementMessageBoundary;
using RailDataEngine.Domain.Services.FeedListener;

namespace RailDataEngine.Services.FeedListener
{
    public class StompTrainMovementListener : ITrainMovementListener
    {
        private readonly ISaveMovementMessageBoundary _boundary;

        public StompTrainMovementListener(ISaveMovementMessageBoundary boundary)
        {
            if (boundary == null)
                throw new ArgumentNullException("boundary");

            _boundary = boundary;
        }

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
                    movementConsumer.Listener += new MessageListener(OnMovementMessage);

                    Console.WriteLine("Consumer started, waiting for messages... (Press ENTER to stop.)");

                    Console.ReadLine();
                    connection.Close();
                }
            }
        }

        private void OnMovementMessage(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;
            msg.Acknowledge();
            _boundary.Invoke(new SaveMovementMessageBoundaryRequest
            {
                MessageToSave = msg.Text
            });
        }
    }
}

