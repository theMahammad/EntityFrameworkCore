using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore
{
    class Program
    {
        public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder => { builder.AddConsole(); });
    static string WrittenProductsInDetail(Product product,ShopContext db){
         return $"{product.Name}| {product.Price} | {db.Categories.Where(cat => cat.Id==product.CategoryId).FirstOrDefault().Name}";
            
    }
    static void ShowFirstProductOnConsole(){
 using(ShopContext db = new ShopContext()){
               var product = db.Products.FirstOrDefault();
               Console.WriteLine(WrittenProductsInDetail(product,db));
                 
           }
            
    }
    static void ShowAllProducts(){
        using(var db = new ShopContext()){
            List<Product> Products= db.Products.ToList();
            foreach(var product in Products){
Console.WriteLine(WrittenProductsInDetail(product,db));
            }
          
        }
    }
    static void GetProductById(int id){
        using(var db = new ShopContext() ){
            var selectedProduct = db.Products.Where(product => product.Id==id).FirstOrDefault(); // Thanks to FirstOrDefault, program don't throw a exception like First() method if a data had not found
            
            Console.WriteLine(WrittenProductsInDetail(selectedProduct,db));
        }
        
    }

    
        static void Main(string[] args)
        {

          ShowAllProducts();
          GetProductById(1);

    }
}
}
