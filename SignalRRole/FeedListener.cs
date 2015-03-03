using System;
using System.Configuration;
using System.Diagnostics;
using Apache.NMS;
using Microsoft.AspNet.SignalR;
using IConnection = Apache.NMS.IConnection;

namespace SignalRRole
{
    public class FeedListener
    {
        private readonly static Lazy<FeedListener> _instance = new Lazy<FeedListener>(
            () => new FeedListener(GlobalHost.ConnectionManager.GetHubContext<RailDataHub>()));

        private readonly IHubContext _context;
        private IConnection _connection;

        public FeedListener(IHubContext context)
        {
            _context = context;
        }

        public void Listen()
        {
            IConnectionFactory factory = new NMSConnectionFactory(new Uri(ConfigurationManager.AppSettings["FeedUri"]));

            using (
                _connection = factory.CreateConnection(ConfigurationManager.AppSettings["FeedUsername"],
                    ConfigurationManager.AppSettings["FeedPassword"]))
            {
                _connection.ClientId = ConfigurationManager.AppSettings["FeedUsername"];
                _connection.Start();

                using (ISession session = _connection.CreateSession())
                {
                    IDestination movementDestination =
                        session.GetDestination(ConfigurationManager.AppSettings["MovementFeedTopic"]);
                    IMessageConsumer movementConsumer = session.CreateConsumer(movementDestination);
                    movementConsumer.Listener += OnMovementMessage;

                    IDestination describerDestination =
                        session.GetDestination(ConfigurationManager.AppSettings["DescriberFeedTopic"]);
                    IMessageConsumer describerConsumer = session.CreateConsumer(describerDestination);
                    describerConsumer.Listener += OnDescriberMessage;

                    Trace.TraceInformation("Message listeners started.");

                    while (true){}
                }
            }
        }

        public void Stop()
        {
            _connection.Close();
        }

        private void OnDescriberMessage(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;
            msg.Acknowledge();

            _context.Clients.All.addMessage(msg.Text);
        }

        private void OnMovementMessage(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;
            msg.Acknowledge();

            _context.Clients.All.addMessage(msg.Text);
        }
    }
}
