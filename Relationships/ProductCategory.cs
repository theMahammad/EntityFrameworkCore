namespace Relationships
{
    public class ProductCategory // this  is a junction class which provide us with many-to-many relationship between Product and Category entitites
    {
        //Primary key of this table will be combination of ProductId and CategoryId
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        
        
    }
}