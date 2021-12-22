using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore
{
    class Program
    {
        public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder => { builder.AddConsole(); });
        static void Main(string[] args)
        {
            
           using(ShopContext db = new ShopContext()){
               var product = new Product{Name = "Vestel Full HD",Price = 2000,CategoryId = db.Categories.Where(cat=>cat.Name=="TV").First().Id};
               db.Products.Add(product);
               db.SaveChanges();
               Console.WriteLine("Data's been added");
               
           }
            

    }
}
}
