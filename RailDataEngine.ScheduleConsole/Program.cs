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
            var container = ContainerBuilder.Build();
            var boundary = container.Resolve<ISaveScheduleMessagesBoundary>();
            var request = new SaveScheduleBoundaryRequest
            {
                MessagesToSave = new List<string>()
            };

            var reader = new StreamReader("schedule.json");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                request.MessagesToSave.Add(line);
            }

            boundary.Invoke(request);
        }
    }
}
