using System;
using System.Collections.Generic;
using System.Linq;
using Relationships;

namespace relationships
{
    class Program
    {
        static void PrintAddingNotification(){
            Console.WriteLine("Data has been added!");
        }
            static void AddUser(User user){

                   using(var db = new Context()){
                      db.Users.Add(user);
                      db.SaveChanges(); 
                      PrintAddingNotification();
                   } 



            }
            static void ShowAllUsers(){
                using (var db = new Context()){
                    var users = db.Users.ToList();
                    foreach(var user in users){
                        Console.WriteLine($@"Id : {user.Id} | Username :   {user.Username} | Email : {user.Email}");

                    }
                }
            }
    static void AddAdressToSpecificUserById(Adress adress,int id){
        using(var db = new Context()){
            var user = db.Users.Where(user => user.Id == id).FirstOrDefault();
            if(user!=null){
                user.Adresses.Add(adress); 
                db.SaveChanges();
                PrintAddingNotification();
                
            }
        }
    }
    static void AddAdress(Adress adress){

        using(var db = new Context()){
            db.Adresses.Add(adress);
            db.SaveChanges();
            PrintAddingNotification();
        }

       
    }
    

    static void ShowAllAdress(){
        using(var db = new Context()){

            var adresses = db.Adresses.ToList();
            foreach (var adress in adresses )
            {
                System.Console.WriteLine($@"{adress.FullAdress}");
            }
        }
    }
    static void AddUserViaAdressTable(){
    var user = new User{Username = "Naghi2021",Email = "eua@mail.ru" };
            var adress = new Adress{FullAdress = "Block 1",User=user}; // Thanks to User=user, we can add a new user to system indirectly
            AddAdress(adress);
    }
    static void ManyToManyAddingExample(){
         using(var db = new Context()){

                var product = new Product{Name="Television",Price=300};
                var categories = new List<Category>{new Category{Name="TV"},new Category{Name = "Technological Device"}};
                
                foreach(var category in categories){
                    product.ProductCategories.Add(new ProductCategory{Category=category});
                }
                db.Products.Add(product);
                db.SaveChanges();
                PrintAddingNotification();
                
    }
    }


        static void Main(string[] args)
        {
             using (var db = new Context()){

               var selectedProduct = db.Products.Where(p=>p.Id==1).FirstOrDefault();
               if(selectedProduct!=null){
                   selectedProduct.ProductCategories = db.ProductCategories.Where(PC=>PC.ProductId==selectedProduct.Id).ToList();
                   foreach(var pc in selectedProduct.ProductCategories){
                       Console.WriteLine($@"{db.Categories.Where(c=> c.Id==pc.CategoryId).FirstOrDefault().Name}");
                   }
               }
           }
          




        }
            
            

        }   
    }

