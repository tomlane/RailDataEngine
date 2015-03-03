using System;
using System.Configuration;
using Apache.NMS;
using RailDataEngine.Domain.Boundary.TrainDescriber.ProcessDescriberMessageBoundary;
using RailDataEngine.Domain.Boundary.TrainMovements.ProcessMovementMessageBoundary;
using RailDataEngine.Domain.Services.FeedListenerService;

namespace RailDataEngine.Services.FeedListener
{
    public class BackgroundStompMessageFeedListener : IMessageFeedListener
    {
        private readonly IProcessMovementMessageBoundary _movementMessageBoundary;
        private readonly IProcessDescriberMessageBoundary _describerMessageBoundary;

        public BackgroundStompMessageFeedListener(IProcessMovementMessageBoundary movementMessageBoundary, IProcessDescriberMessageBoundary describerMessageBoundary)
        {
            if (movementMessageBoundary == null)
                throw new ArgumentNullException("movementMessageBoundary");

            if (describerMessageBoundary == null)
                throw new ArgumentNullException("describerMessageBoundary");

            _movementMessageBoundary = movementMessageBoundary;
            _describerMessageBoundary = describerMessageBoundary;
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
                    movementConsumer.Listener += OnMovementMessage;

                    IDestination describerDestination =
                        session.GetDestination(ConfigurationManager.AppSettings["DescriberFeedTopic"]);
                    IMessageConsumer describerConsumer = session.CreateConsumer(describerDestination);
                    describerConsumer.Listener += OnDescriberMessage;

                    Console.WriteLine("Message listeners started.");

                    Console.ReadLine();
                    connection.Close();
                }
            }
        }

        private void OnDescriberMessage(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;
            msg.Acknowledge();

            _describerMessageBoundary.Invoke(new ProcessDescriberMessageBoundaryRequest
            {
                MessageToSave = msg.Text
            });
        }

        private void OnMovementMessage(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;
            msg.Acknowledge();

            _movementMessageBoundary.Invoke(new ProcessMovementMessageBoundaryRequest
            {
                MessageToSave = msg.Text
            });
        }
    }
}

