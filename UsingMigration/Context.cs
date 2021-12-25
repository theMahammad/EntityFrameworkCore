using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace UsingMigration
{
    public class Context:DbContext
    {
        public DbSet<Author> Authors { get ; set;}
        public DbSet<Article> Articles { get; set; }
        
        protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            
           
           
          
          optionsBuilder.UseSqlServer(@"Data Source =(localdb)\MSSQLLocalDB;Database=BlogDB;Integrated Security=SSPI "); 
       //Since this project is code first, database will be created in the server 
      
           }
          
}
}