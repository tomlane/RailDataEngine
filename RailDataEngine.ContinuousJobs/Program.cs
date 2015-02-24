using Microsoft.Azure.WebJobs;

namespace RailDataEngine.ContinuousJobs
{
    class Program
    {
        static void Main()
        {
            var host = new JobHost();

            host.CallAsync(typeof(Listener).GetMethod("MovementListener"));

            host.RunAndBlock();
        }
    }
}
