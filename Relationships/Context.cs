using Microsoft.EntityFrameworkCore;

namespace Relationships
{
    public class Context:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

            optionsBuilder.UseSqlite("Data Source = Db.db");
        }
    }
}