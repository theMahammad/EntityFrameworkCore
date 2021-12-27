using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Relationships
{
    public class User
    {
        public User(){

                this.Adresses = new List<Adress>();
        }
        [Key] //it is not necessary
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string Username { get; set; }

        [MaxLength(100)]
        
        public string Email { get; set; }
        public Customer Customer { get; set; } // This code provide us with one-to-one relationship between User and Customer
        public List<Adress> Adresses { get; set; }
    }
}