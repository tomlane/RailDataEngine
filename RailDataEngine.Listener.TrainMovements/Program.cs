using System;
using System.Configuration;
using Apache.NMS;

namespace RailDataEngine.Listener.TrainMovements
{
    class Program
    {
        static void Main(string[] args)
        {
            StartListener();
        }

        private static void StartListener()
        {
            IConnectionFactory factory = new NMSConnectionFactory(new Uri("stomp:tcp://datafeeds.networkrail.co.uk:61618"));

            using (
                IConnection connection = factory.CreateConnection(ConfigurationManager.AppSettings["FeedUsername"],
                    ConfigurationManager.AppSettings["FeedPassword"]))
            {
                connection.ClientId = ConfigurationManager.AppSettings["FeedUsername"];
                connection.Start();

                using (ISession session = connection.CreateSession())
                {
                    IDestination movementDestination = session.GetDestination("topic://" + "TRAIN_MVT_EF_TOC");
                    IMessageConsumer movementConsumer = session.CreateConsumer(movementDestination);
                    movementConsumer.Listener += new MessageListener(OnMovementMessage);

                    Console.WriteLine("Consumer started, waiting for messages... (Press ENTER to stop.)");

                    Console.ReadLine();
                    connection.Close();
                }
            }
        }

        private static void OnMovementMessage(IMessage message)
        {
            try
            {
                Console.WriteLine("Movement message received.");

                ITextMessage msg = (ITextMessage)message;
                message.Acknowledge();

                Console.WriteLine(msg.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("---");
                Console.WriteLine(ex.InnerException);
                Console.WriteLine("---");
                Console.WriteLine(ex.InnerException.Message);
            }
        }
    }
}
