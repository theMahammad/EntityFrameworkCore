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
    static void AddProduct(Product product){
        using(var db = new ShopContext()){
            db.Products.Add(product);
            db.SaveChanges();
            Console.WriteLine("Data's been added!");
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
    static Product GetProductById(int id){
        using(var db = new ShopContext() ){
            var selectedProduct = db.Products.Where(product => product.Id==id).FirstOrDefault(); // Thanks to FirstOrDefault, program don't throw a exception like First() method if a data had not found
            
           return selectedProduct;
        }
        
    }
    static void UpdateProduct(Product product){
        //Change tracking
        using(var db = new ShopContext()){
            var calledProduct = db.Products.Where(p => p.Id==product.Id).FirstOrDefault();
            if (!(calledProduct is null)){
                    calledProduct.Name = product.Name;
                    calledProduct.Price = product.Price;
                    calledProduct.CategoryId = product.CategoryId;
                    
                    
                    db.SaveChanges();
                    Console.WriteLine("Data's been updated");
                  
            } 
        }
            


    }


    
        static void Main(string[] args)
        {

          ShowAllProducts();
         var product =GetProductById(1);
         product.Name="Vestel Smart TV"; //Data's been updated
         UpdateProduct(product);
                   
          
          

    }
}
}
