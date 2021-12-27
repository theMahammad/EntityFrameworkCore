using System;
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


        static void Main(string[] args)
        {
            
            var customer = new Customer{FirstName = "Elovset", LastName = "Isgenderov",IdentityNumber = "123EACR"};
            var user = new User{Username = "elovset123", Email = "elovset@yahoo.com" , Customer = customer};
            AddUser(user);

        }   
    }
}
