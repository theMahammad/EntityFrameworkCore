using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Relationships
{
    public class Customer
    {
        public int Id { get; set; }
        [Column(TypeName ="varchar(15)")]
        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        
        public string FirstName { get; set;}
        [Required]
        public string LastName { get; set;}
        public User User { get; private set;}
        [Required]
        public int UserId { get; set; }
    }
}