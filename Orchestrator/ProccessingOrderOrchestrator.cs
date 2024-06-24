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
            [OrchestrationTrigger] IDurableOrchestrationContext context, ILogger log)
        {
            var orderItem = context.GetInput<OrderItem>();

            log.LogInformation($"Starting order processing for order ID: {orderItem.OrderID}");

            //Updating the database

            await context.CallActivityAsync("UpdateDatabase(Order)", orderItem);

            //Send Order Confirmation
            await context.CallActivityAsync("OrderConfirmation", orderItem.OrderID);

            //Send Notificaion
            await context.CallActivityAsync("NotificationOrchestra", orderItem.OrderID);

            log.LogInformation($"Ordering process complete for order ID: {orderItem.OrderID}");
        }
    }
}
