using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAnnotations_FluentAPI
{
    //(1) Setting a column as not null
    //(2) Setting Primary key
    //(3) Including a type(class) to model
    //(4) Excluding a type(class) from model
    //(5) Customizing the name of tables
    public class MyDBContext:DbContext
    {   //There are some ways to include types(classes) in the model. (3)
        public DbSet<Blog> Blogs { get; set; } // First one is declaring a property with DBSet<ClassName> type (3)  
        public DbSet<Study> Studies { get; set; }
        protected  override void OnModelCreating(ModelBuilder modelBuilder){
                
                modelBuilder.Entity<Blog>()
                        .Property(b=>b.Title)
                        .IsRequired(); // This is the second way to set it not null, which named Fluent API(1)
        
                modelBuilder.Entity<Student>()  //Second one is the called the class by creating a instance of generic Entity type(3)
                        .HasKey(k => k.StudentNumber); //(2)
                modelBuilder.Entity<Post>();//Despite  using [NotMapped] above the declaring the class, 
                // if we create a instance at the level of Fluent API, the class will be included in the model. EF always prefer Fluent API.(4)
                
                modelBuilder.Ignore<Study>(); // We have mentioned that if a class  is used with DbSet<> to declare a property,EF include it into Model.
                //But we have also mentioned that EF always prefer Fluent API. So, if we call Ignore method, EF exclude the class we specify (4)

                modelBuilder.Entity<Blog>().ToTable("blogger"); //We can also use this way for naming tables                        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

            optionsBuilder.UseSqlite("Data Source=Db.db");
        }
        
        
        
    }
    
 
    
    public class Study{
        public int Id { get; set; }
    }
    [Table("Blogg")] //If we want to customize the name of a table, we can use this (5)
    public class Blog{

        public int Id { get; set;}
        //[Required] // This is first way to set it not null,which named Data Annotations (1)
        public string Title { get; set; } //This column is nullable in default. There are two way to set this column not null(1)

        public List<Post> Posts { get; set; } // And the last one is declaring a class a List format in the another class (3)
        
    }
    public class Student{

        //public int Id{ get; set; } 
        //public int StudentId { get; set;} in both cases Entity perceive the column as Primary Key. (2)
        //But if we want to use different named primary key, we have to indicate this state.(2)
        [Key] //(2)
        public int StudentNumber { get; set;}

    }
    [NotMapped] // If we want to specify a class which is not wanted to be modeled to EF, we can use [NotMapped] attribute (4) 
    public class Post{

        public int Id { get; set; }
        public Blog Blog { get; private set;}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
         
        }
    }
}
