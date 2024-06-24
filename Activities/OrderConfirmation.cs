using CLOUD_POE_Part2.Data;
using CLOUD_POE_Part2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;

namespace CLOUD_POE_Part2.Activities
{
    public class OrderConfirmation
    {
        [FunctionName("OrderConfirmation")]
        public async Task<string> ConfirmOrder([ActivityTrigger] IDurableOrchestrationContext context)
        {
            List<Product> orderList = context.GetInput<List<Product>>();

            orderList.Clear();

            return "Order confirmed successfully!";
        }
    }
}
