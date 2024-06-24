using CLOUD_POE_Part2.Data;
using CLOUD_POE_Part2.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace CLOUD_POE_Part2.Activities
{
    public class UpdateDatabase
    {
        [FunctionName("UpdateDatabase(Order)")]
        public static async Task UpdatesDatabase([ActivityTrigger] OrderItem orderItemToUpdate)
        {
            using (var dbContext = new SystemDbContext())
            {
                var existingOrderItem = await dbContext.Item.FindAsync(orderItemToUpdate.OrderItemID);

                if (existingOrderItem != null)
                {
                    existingOrderItem.quantity = orderItemToUpdate.quantity;
                    existingOrderItem.Price = orderItemToUpdate.Price;

                    // Update other properties as needed
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
