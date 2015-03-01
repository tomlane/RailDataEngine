using Microsoft.Azure.WebJobs;
using Microsoft.Practices.Unity;
using RailDataEngine.Core;
using RailDataEngine.Domain.Boundary.TrainMovements.ProcessMovementMessageBoundary;

namespace RailDataEngine.ContinuousJobs
{
    public static class Messages
    {
        public static void ProcessMovementMessages([QueueTrigger("trainmovementmessages")] string messageContent)
        {
            var container = ContainerBuilder.Build();

            var boundary = container.Resolve<IProcessMovementMessageBoundary>();

            boundary.Invoke(new ProcessMovementMessageBoundaryRequest
            {
                MessageToSave = messageContent
            });
        }
    }
}
