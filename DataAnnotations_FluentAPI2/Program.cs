using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataAnnotations_FluentAPI2
{
    class Program
    {
        //(1) Customize the name of  the columns
        //(2) Elaborating the type of columns
        
        public class Context:DbContext{

            public DbSet<User> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source = (localDB)\MSSQLLocalDB;Database=TestDB;Integrated Security=SSPI");
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>().Property(u=> u.Name).HasColumnName("CustomizedName"); //(1)
                modelBuilder.Entity<User>().Property(u=>u.IdentityNumber).HasColumnType("nvarchar(25)"); //(2)
                
            }

        }
        public class User{
            public int Id { get; set; }
            [Column("UserName")]  //As we can do with the tables, we can also customize the name of the columns (1)
            public string Name { get; set; }
            
            //As you know string type is able to store a data with very big length more than we need, so we should restrict it (2)
            [Column(TypeName ="nvarchar(20)")]
            //[MaxLength(20)] if we want to just restrict the maximum length,we can also use MaxLength attribute. But our topic is about elaborating type (2)
            public string IdentityNumber { get; set; }

        }

        static void Main(string[] args)
        {
            
        }
    }
}
