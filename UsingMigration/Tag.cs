using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsingMigration
{
    public class Tag
    {
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName ="nvarchar(30)")]
        public string Name { get; set; }
        


        
    }
}