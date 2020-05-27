using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Policy;

namespace LibraryRestApi.DataAccessLayer.Entities
{
    public class ChapterEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public BookEntity Book { get; set; }
    }
}