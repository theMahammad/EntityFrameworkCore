using Microsoft.EntityFrameworkCore;
namespace EntityFrameworkCore
{
    public class ShopContext:DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("Data Source=shop.db");
        }
    

    }
}