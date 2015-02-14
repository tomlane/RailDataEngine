using Microsoft.Azure.WebJobs;

namespace RailDataEngine.ListenerJob
{
    class Program
    {
        static void Main()
        {
            var host = new JobHost();
            host.CallAsync(typeof(Functions).GetMethod("ListenForMovements"));
            host.CallAsync(typeof(Functions).GetMethod("ListenForScheduleChanges"));
            host.RunAndBlock();
        }
    }
}
