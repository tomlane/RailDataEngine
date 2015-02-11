using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using RailDataEngine.DI;
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

            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
            
            var reader = new StreamReader("schedule.json");
            List<string> lines = reader.ReadLines(1000000);

            Parallel.ForEach(lines, SaveMessage);

            Console.WriteLine("Schedule imported successfully.");
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
