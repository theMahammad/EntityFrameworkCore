using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataAnnotations_FluentAPI
{

    public class MyDBContext:DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        
        protected  override void OnModelCreating(ModelBuilder modelBuilder){
                
                modelBuilder.Entity<Blog>()
                        .Property(b=>b.Title)
                        .IsRequired(); // This is the second way to set it not null, which named Fluent API(1)
        
                modelBuilder.Entity<Student>()
                        .HasKey(k => k.StudentNumber); //(2)
                        
        }
        
    }

    public class Blog{

        public int Id { get; set;}
        //[Required] // This is first way to set it not null,which named Data Annotations (1)
        public string Title { get; set; } //This column is nullable in default. There are two way to set this column not null(1)


    }
    public class Student{

        //public int Id{ get; set; } 
        //public int StudentId { get; set;} in both cases Entity perceive the column as Primary Key. (2)
        //But if we want to use different named primary key, we have to indicate this state.(2)
        [Key] //(2)
        public int StudentNumber { get; set;}

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
        }
    }
}
