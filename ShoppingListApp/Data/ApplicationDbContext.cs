using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ShoppingListApp.Data;

namespace ShoppingListApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
        public DbSet<ShoppingProduct> ShoppingProducts { get; set; }
    }
}












