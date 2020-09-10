using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Local.Functions
{
    public static class QueueTriggeredFunction
    {
        [FunctionName("Queue")]
        public async static Task Run(
            [QueueTrigger("%QueueName%", Connection = "AzureWebJobsStorage")] string message,
            ILogger log)
        {
            log.LogInformation($"Received message on {System.Environment.GetEnvironmentVariable("QueueName")}: {message}");
        }
    }
}
