using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore
{
    class Program
    {
        public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder => { builder.AddConsole(); });
    static void ShowFirstProductOnConsole(){
 using(ShopContext db = new ShopContext()){
               var product = db.Products.FirstOrDefault();
               
               Console.WriteLine($"{product.Name}| {product.Price} | {db.Categories.Where(cat => cat.Id==product.CategoryId).FirstOrDefault().Name}");
               
           }
            
    }
    
        static void Main(string[] args)
        {
            ShowFirstProductOnConsole();
          

    }
}
}
