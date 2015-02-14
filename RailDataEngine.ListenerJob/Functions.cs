using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Practices.Unity;
using RailDataEngine.DI;
using RailDataEngine.Domain.Services.FeedListenerService;

namespace RailDataEngine.ListenerJob
{
    public class Functions
    {
        [NoAutomaticTrigger]
        public static void ListenForMovements()
        {
            var container = ContainerBuilder.Build();
            var listener = container.Resolve<ITrainMovementListener>();
            listener.Listen();
        }

        [NoAutomaticTrigger]
        public static void ListenForScheduleChanges()
        {
            Console.WriteLine("Schedule listener started.");
        }
    }
}
