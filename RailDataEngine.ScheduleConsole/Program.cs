using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using RailDataEngine.Core;
using RailDataEngine.Domain.Boundary.Schedule.SaveScheduleMessageBoundary;

namespace RailDataEngine.ScheduleConsole
{
    class Program
    {
        private static IUnityContainer _container;
        private static int _counter;

        static void Main(string[] args)
        {
            _container = ContainerBuilder.Build();

            var lines = File.ReadAllLines("schedule.json");

            foreach (var line in lines)
            {
                SaveMessage(line);
            }

            Console.WriteLine("Schedule imported successfully.");
            Console.ReadLine();
        }

        private static void SaveMessage(string message)
        {
            _counter++;
            var boundary = _container.Resolve<ISaveScheduleMessagesBoundary>();
            var request = new SaveScheduleBoundaryRequest
            {
                MessagesToSave = new List<string>
                {
                    message
                }
            };
            boundary.Invoke(request);
            Console.WriteLine("{0} records saved.", _counter);
        }
    }
}
