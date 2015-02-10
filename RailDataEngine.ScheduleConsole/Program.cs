using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Practices.Unity;
using RailDataEngine.DI;
using RailDataEngine.Domain.Boundary.Schedule.SaveScheduleMessageBoundary;

namespace RailDataEngine.ScheduleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const int lineCount = 100;

            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<ISaveScheduleMessagesBoundary>();
            
            var reader = new StreamReader("schedule.json");
            List<string> lines;
            int counter = 0;
            
            while ((lines = reader.ReadLines(lineCount)) != null)
            {
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
