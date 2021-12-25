using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore
{
    public class Product
    {
        public int Id { get; set; } // If we use "Id" or "ProductId" as name while declaring a variable, 
        //Entity perceive this as a primary key for Product table. But if we want to use other names,we have to use [Key] attribute before declaring command to enable entity to perceive it as primary key
        [MaxLength(100)] // We've informed Entity that Name column is able to hold a string of up to 100 character
        [Required] // not null
        public string Name { get; set;}
        
        public decimal Price { get; set; }
       public int CategoryId { get; set; }
        public Category Category { get; set;} 
    }
}