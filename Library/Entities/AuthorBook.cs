using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Library.Entities
{
    public class AuthorBook
    {
        public int Id { get; set; }
        [Required]
        public Author Author { get; set; }
        [Required]
        public Book Book { get; set; } 
    }
}