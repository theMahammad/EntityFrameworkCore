using Microsoft.EntityFrameworkCore;

namespace Relationships
{
    public class Context:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products {get;set;}
        public DbSet<Category> Categories { get;  set; }
        
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

            optionsBuilder.UseSqlite("Data Source = Db.db");
        }
        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                            .HasKey(pc=> new {pc.ProductId,pc.CategoryId});
            modelBuilder.Entity<ProductCategory>()
                            .HasOne(pc=>pc.Product)
                            .WithMany(p=>p.ProductCategories)
                            .HasForeignKey(pc=>pc.ProductId);
            
            modelBuilder.Entity<ProductCategory>()
                            .HasOne(pc=>pc.Category)
                            .WithMany(c=>c.ProductCategories)
                            .HasForeignKey(pc=>pc.CategoryId);                            
        }
    }
}