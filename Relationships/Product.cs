using System.Collections.Generic;
using Relationships;
namespace Relationships
{
    public class Product
    {
        
        public Product(){
            this.ProductCategories = new List<ProductCategory>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<ProductCategory> ProductCategories { get; set;}

    }
}