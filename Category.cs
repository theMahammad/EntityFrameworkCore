using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set;}
    }
}