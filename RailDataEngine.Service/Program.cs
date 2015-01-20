using System;
using System.ServiceProcess;
using RailDataEngine.DI;

namespace RailDataEngine.Service
{
    public static class Program
    {
        public const string ServiceName = "RailDataEngine";

        public class Service : ServiceBase
        {
            public Service()
            {
                ServiceName = Program.ServiceName;
            }

            protected override void OnStart(string[] args)
            {
                Start(args);
            }

            protected override void OnStop()
            {
                Program.Stop();
            }
        }

        static void Main(string[] args)
        {
            var container = ContainerBuilder.Build();

            if (!Environment.UserInteractive)
                // running as service
                using (var service = new Service())
                    ServiceBase.Run(service);
            else
            {
                // running as console app
                Start(args);

                Console.WriteLine("Press any key to stop...");
                Console.ReadKey(true);

                Stop();
            }
        }

        private static void Start(string[] args)
        {
            // start feed listners
        }

        private static void Stop()
        {
            // stop feed listeners
        }
    }
}
