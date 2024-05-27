using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CLOUD_POE_Part2.Models;
using Microsoft.EntityFrameworkCore;
using CLOUD_POE_Part2.Data;

public class OrderController : Controller
{
    private readonly SystemDbContext _context;

    public OrderController(SystemDbContext context)
    {
        _context = context;
    }

    // Temporary storage for the list of products
    private static List<Product> _orderItems = new List<Product>();

    // Add product to list
    [HttpPost]
    public IActionResult AddToOrder(int productId)
    {
        var product = _context.Product.FirstOrDefault(p => p.ProductID == productId);
        if (product != null)
        {
            _orderItems.Add(product);
        }
        return Ok();
    }

    // Display the list of order items
    public IActionResult OrderItems()
    {
        return View(_orderItems);
    }
}

