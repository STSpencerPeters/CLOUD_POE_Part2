using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLOUD_POE_Part2.Data;
using CLOUD_POE_Part2.Models;

namespace CLOUD_POE_Part2.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly SystemDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProductsController(SystemDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            // Get the logged-in user's ID
            var userId = _userManager.GetUserId(User);

            // Retrieve all products
            var products = await _context.Product.ToListAsync();

            // Check if the logged-in user is an Admin
            var isAdmin = await _userManager.IsInRoleAsync(await _userManager.FindByIdAsync(userId), "Admin");
            ViewBag.IsAdmin = isAdmin;

            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductName,ProductCategory,ProductPrice")] Product product, IFormFile productImage)
        {
            if (ModelState.IsValid)
            {
                if (productImage != null && productImage.Length > 0)
                {
                    // Handle image upload
                    var fileName = Path.GetFileName(productImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await productImage.CopyToAsync(stream);
                    }

                    // Set the ProductImage property of the product
                    product.ProductImageUrl = "/images/" + fileName;
                }

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,ProductCategory,ProductPrice,ProductImageUrl")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Products/AddToCart
        [HttpPost]
        [Authorize(Roles = "Customer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var userId = _userManager.GetUserId(User);
            var customer = await _context.Customer.SingleOrDefaultAsync(c => c.Id == userId);

            if (customer == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            var orderItem = new OrderItem
            {
                ProductID = productId,
            };

            _context.Item.Add(orderItem);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id);
        }
    }
}
