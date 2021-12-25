using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsingMigration
{

    [Table("OurAuthors",Schema="Github")] // This table will be created as named Github.OurAuthor
    public class Author

    {  [Column("AuthorId",Order =0)] 
         public int Id { get; set;}    

        [Column("Namee",TypeName ="nvarchar(50)",Order =2)]
        [Required]
        public string Name { get; set;}
        [Column("Agee",Order =1)]
        [Required]
        public byte Age { get;set;}
        public ICollection<Article> Articles { get; set; }
    }
}