using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsingMigration
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(200)")]
        public string Description{ get; set;}
        [Required]
        [Column(TypeName ="ntext")]
        public string Body { get; set;}
        [Required]
        [ForeignKey("OurAuthors")]
        public int AuthorId { get; set;}
        public Author Author {get; set;}
        [Required]
        [Column(TypeName ="DateTime2")]
        public DateTime Date {get; set;}
    }
}