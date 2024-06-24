using CLOUD_POE_Part2.Data;
using CLOUD_POE_Part2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;

namespace CLOUD_POE_Part2.Activities
{
    /*
     * Code Attribution:
     * Mrzyglod. (2022). | Azure for Developers
     * This reference helped me get an idea of how to set up an durable function that used an HTTP trigger.
     */
    public class StartOrderProcessing
    {
        [FunctionName("ProccessingOrderOrchestrator")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "start-order")] HttpRequest req,
        [DurableClient] IDurableOrchestrationClient starter)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var orderItem = JsonConvert.DeserializeObject<OrderItem>(requestBody);

            string instanceId = await starter.StartNewAsync("ProcessOrderOrchestrator", orderItem);

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}
