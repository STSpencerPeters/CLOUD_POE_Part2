using System.Collections.Generic;
using System.Threading.Tasks;
using CLOUD_POE_Part2.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging; 

namespace CLOUD_POE_Part2.Orchestrator
{
    public class ProccessingOrderOrchestrator
    {
        [FunctionName("ProccessingOrderOrchestrator")]
        
        public static async Task RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var orderItem = context.GetInput<OrderItem>();


            //Updating the database

            await context.CallActivityAsync("UpdateDatabase(Order)", orderItem);

            //Send Order Confirmation
            await context.CallActivityAsync("OrderConfirmation", orderItem.OrderID);

        }
    }
}
