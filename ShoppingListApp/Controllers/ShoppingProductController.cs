using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoppingListApp.Controllers
{
    public class ShoppingProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService _authorizationService;

        public ShoppingProductController(ApplicationDbContext context, IAuthorizationService authorizationService)
        {
            _context = context;
            _authorizationService = authorizationService;
        }

        // POST: /ShoppingProduct/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ProductName, ShoppingListId")] ShoppingProduct shoppingProduct)
        {
            var list = await _context.ShoppingListItems
                .Include(l => l.Owner)
                .FirstOrDefaultAsync(l => l.Id == shoppingProduct.ShoppingListId);

            if (list == null || list.OwnerId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                shoppingProduct.OwnerId = list.OwnerId;
                _context.Add(shoppingProduct);
                await _context.SaveChangesAsync();
                return Json(new { id = shoppingProduct.Id, productName = shoppingProduct.ProductName });
            }
            return BadRequest();
        }


        // POST: /ShoppingProduct/ToggleProduct/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ToggleProduct(int id)
        {
            var product = await _context.ShoppingProducts
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null || product.Owner.Id != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Forbid();
            }

            product.IsChecked = !product.IsChecked;
            _context.Update(product);
            await _context.SaveChangesAsync();

            return Json(new { isChecked = product.IsChecked, productName = product.ProductName });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.ShoppingProducts
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null || product.Owner.Id != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Forbid();
            }

            var listId = product.ShoppingListId;
            _context.ShoppingProducts.Remove(product);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
    }
}
