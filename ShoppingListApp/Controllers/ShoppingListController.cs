using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListApp.Controllers
{
    public class ShoppingListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppingListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShoppingList
        public async Task<IActionResult> Index()
        {
            var lists = await _context.ShoppingListItems.Include(l => l.Products).ToListAsync();
            return View(lists);
        }

        // GET: ShoppingList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list = await _context.ShoppingListItems
                .Include(l => l.Products)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (list == null)
            {
                return NotFound();
            }

            return View(list);
        }

        // GET: ShoppingList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ListName")] ShoppingListItem shoppingListItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingListItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingListItem);
        }

        // GET: ShoppingList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingListItem = await _context.ShoppingListItems.FindAsync(id);
            if (shoppingListItem == null)
            {
                return NotFound();
            }
            return View(shoppingListItem);
        }

        // POST: ShoppingList/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ListName")] ShoppingListItem shoppingListItem)
        {
            if (id != shoppingListItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingListItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingListItemExists(shoppingListItem.Id))
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
            return View(shoppingListItem);
        }

        // GET: ShoppingList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingListItem = await _context.ShoppingListItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingListItem == null)
            {
                return NotFound();
            }

            return View(shoppingListItem);
        }

        // POST: ShoppingList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingListItem = await _context.ShoppingListItems.FindAsync(id);
            if (shoppingListItem == null)
            {
                return NotFound();
            }

            try
            {
                _context.ShoppingListItems.Remove(shoppingListItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingListItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ShoppingListItemExists(int id)
        {
            return _context.ShoppingListItems.Any(e => e.Id == id);
        }
    }
}


