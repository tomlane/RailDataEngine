using Microsoft.Azure.WebJobs;
using Microsoft.Practices.Unity;
using RailDataEngine.Core;
using RailDataEngine.Domain.Services.FeedListenerService;

namespace RailDataEngine.ContinuousJobs
{
    public class Listener
    {
        [NoAutomaticTrigger]
        public static void MovementListener()
        {
            var container = ContainerBuilder.Build();

            var movementListener = container.Resolve<ITrainMovementListener>();

            movementListener.Listen();
        }
    }
}
