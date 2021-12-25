using System;
using System.Collections.Generic;
using System.Linq;

namespace UsingMigration
{
    class Program
    {
        static void PrintAddingNotification(){
            Console.WriteLine("Data has been added!");
            
                    }
        static void PrintUpdatingNotification(){
            Console.WriteLine("Data has been updated!");
        }                    
        public  static void AddAuthor(Author author){
                using(var db = new Context() ){
                    db.Authors.Add(author);
                    db.SaveChanges();
                    PrintAddingNotification();
                    
                }
        }
        public static Author GetAuthorById(int id){
            using (var db = new Context()){
                var calledAuthor = db.Authors.Where(author=> author.Id == id).FirstOrDefault();
                if(calledAuthor!=null){
                    return calledAuthor;
                }
                return new Author();

            }
        }
        public static void PrintSelectedAuthor(Author author){
           Console.WriteLine($@" Id : {author.Id}| Name : {author.Name}| Age : {author.Age}| Number of articles written : {author.Articles.Count()}" );
        }
        public static void AddArticle(Article article){
           using(var db = new Context()){
               db.Articles.Add(article);
                db.SaveChanges();
                PrintAddingNotification();
                
        }
        }
        public static void UpdateAuthor(Author author){
            using(var db = new Context()){
                db.Authors.Attach(author);
               
                author.WorkExperience = 3;
                db.SaveChanges();
                PrintUpdatingNotification();
            }
        }   
        
        static void Main(string[] args)
        {
            
            
                
                

            }
            
        
    }
}
