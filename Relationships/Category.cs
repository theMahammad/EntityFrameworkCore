using relationships;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Relationships{

    public class Category{

        public int Id { get; set; }
        
        public string Name { get; set; }
        public List<ProductCategory> ProductCategories { get; set;}
        


    }


}