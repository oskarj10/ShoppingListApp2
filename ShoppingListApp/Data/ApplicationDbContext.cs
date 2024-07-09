using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShoppingListApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
        public DbSet<ShoppingProduct> ShoppingProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure cascading delete for ShoppingListItem and ShoppingProduct
            builder.Entity<ShoppingListItem>()
                .HasMany(s => s.Products)
                .WithOne(p => p.ShoppingList)
                .HasForeignKey(p => p.ShoppingListId)
                .OnDelete(DeleteBehavior.Cascade); // Ensure cascading delete
        }
    }
}














