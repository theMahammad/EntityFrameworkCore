using Microsoft.EntityFrameworkCore;
namespace EntityFrameworkCore
{
    public class ShopContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            
           
           optionsBuilder.
           UseLoggerFactory(Program.MyLoggerFactory)
           .UseSqlite("Data Source=shop.db");
        }
    

    }
}