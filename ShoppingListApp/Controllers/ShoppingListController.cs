using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data;

using System.Linq;

namespace ShoppingListApp.Controllers
{
    public class ShoppingListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppingListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Akcja do wyświetlania listy zakupów na stronie głównej
        public IActionResult Index()
        {
            var shoppingListItems = _context.ShoppingListItems.ToList();
            return View(shoppingListItems);
        }

        // Akcja do dodawania nowego wpisu na listę zakupów
        [HttpPost]
        public IActionResult AddItem(string description)
        {
            var newItem = new ShoppingListItem
            {
                Description = description,
                IsChecked = false
            };

            _context.ShoppingListItems.Add(newItem);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Akcja do skreślania wpisu na liście zakupów
        [HttpPost]
        public IActionResult CrossOffItem(int id)
        {
            var item = _context.ShoppingListItems.Find(id);
            if (item != null && !item.IsChecked)
            {
                item.IsChecked = true;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // Akcja do edycji opisu wpisu na liście zakupów
        [HttpPost]
        public IActionResult EditDescription(int id, string description)
        {
            var item = _context.ShoppingListItems.Find(id);
            if (item != null)
            {
                item.Description = description;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
