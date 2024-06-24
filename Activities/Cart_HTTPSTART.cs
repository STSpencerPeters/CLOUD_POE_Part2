using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;

namespace CLOUD_POE_Part2.Activities
{
    public class Cart_HTTPSTART
    {
        [FunctionName("Cart_HttpStart")]
        public static async Task<HttpResponseMessage> HTTPSTART(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestMessage req,
        [DurableClient] IDurableOrchestrationClient starter,
        ILogger log)
        {
            // Parse query parameter
            string instanceId = await starter.StartNewAsync("OrderConfirmation", null);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}
