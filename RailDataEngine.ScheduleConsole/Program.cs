using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Practices.Unity;
using RailDataEngine.DI;
using RailDataEngine.Domain.Boundary.Schedule.SaveScheduleMessageBoundary;

namespace RailDataEngine.ScheduleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

            const int lineCount = 10000;

            var container = ContainerBuilder.Build();
            
            var reader = new StreamReader("schedule.json");
            List<string> lines;
            int counter = 0;
            
            while ((lines = reader.ReadLines(lineCount)).Count > 1)
            {
                var boundary = container.Resolve<ISaveScheduleMessagesBoundary>();
                var request = new SaveScheduleBoundaryRequest
                {
                    MessagesToSave = lines
                };
                counter += lines.Count;
                boundary.Invoke(request);
                Console.WriteLine("{0} lines imported.", counter);
            }

            Console.WriteLine("Schedule imported successfully.");
        }
    }
}
