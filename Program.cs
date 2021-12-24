using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

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
    static void PrintUpdatingNotification(){
        Console.WriteLine("Data's been updated");
    }
    static void PrintDeleteNotification(){
        Console.WriteLine("Data's been deleted");
    }
    static void UpdateProduct(Product product){
        //Change tracking
        using(var db = new ShopContext()){
            //db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; // With write this command, we can prevent change tracking
            var calledProduct = db.Products.Where(p => p.Id==product.Id).FirstOrDefault();
           
            
            
            if (!(calledProduct is null)){
                    calledProduct.Name = product.Name;
                    calledProduct.Price = product.Price;
                    calledProduct.CategoryId = product.CategoryId;
                    
                    
                    db.SaveChanges();
                   PrintUpdatingNotification();
                  
            } 
        }
            


    }
    static void UpdateProductWay2(int id){
            using(var db = new ShopContext()){
                var product = new Product{  Id = id };
                db.Products.Attach(product); //Thanks to the Attach method,we can enable system to track it
                product.Name = "Samsung Smart TV";
                
                db.SaveChanges();
                PrintUpdatingNotification();
            }
    }

    static void UpdateProductWay3(int id){
        using(var db = new ShopContext()){
    var product = GetProductById(id);
        
        if(product!=null){
            product.Price=5000;
            db.Products.Update(product);
            db.SaveChanges();
            PrintUpdatingNotification();
            
        }
        }
        
    }
    static void DeleteProduct(int id){
        using(var db = new ShopContext()){
            var product = GetProductById(id);
            if(product!=null){
                db.Products.Remove(product);
                //db.Remove(product); we can also use this method instead of the above method
                db.SaveChanges();

            }
        }
    }


    
        static void Main(string[] args)
        {

          ShowAllProducts();
         UpdateProductWay3(1);
          
          

    }
}
}
