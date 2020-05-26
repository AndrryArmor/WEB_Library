using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Library.Entities
{
    public class AuthorBookEntity
    {
        public int Id { get; set; }
        [Required]
        public AuthorEntity Author { get; set; }
        [Required]
        public BookEntity Book { get; set; } 
    }
}