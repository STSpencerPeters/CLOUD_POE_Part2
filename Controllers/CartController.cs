using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CLOUD_POE_Part2.Models;
using Microsoft.EntityFrameworkCore;
using CLOUD_POE_Part2.Data;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

public class CartController : Controller
{
    private readonly SystemDbContext _context;
    private readonly IDurableOrchestrationClient _durableOrchestrationClient;

    public CartController(SystemDbContext context, IDurableOrchestrationClient durableContextClient)
    {
        _context = context;
        _durableOrchestrationClient = durableContextClient;
    }

    // Temporary storage for the list of products
    List<Product> _orderList = new List<Product>();

    // Add product to list
    [HttpPost]
    public IActionResult AddToOrder(int productId)
    {
        var product = _context.Product.FirstOrDefault(p => p.ProductID == productId);
        if (product != null)
        {
            _orderList.Add(product);
        }
        return Ok();
    }

    // Display the list of order items
    public IActionResult OrderItems()
    {
        return View(_orderList);
    }

    // Trigger order confirmation
    public async Task<IActionResult> ConfirmOrder()
    {
        // Start the order confirmation orchestration
        string instanceId = await _durableOrchestrationClient.StartNewAsync("OrderConfirmation", null);

        return RedirectToAction("OrderConfirmed", new { instanceId });
    }

    public IActionResult OrderConfirmed(string instanceId)
    {
        return View(instanceId);
    }
}

