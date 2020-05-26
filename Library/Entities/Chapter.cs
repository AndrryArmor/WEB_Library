using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Policy;

namespace Library.Entities
{
    public class Chapter
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Book Book { get; set; }
    }
}