using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LibraryRestApi.DataAccessLayer.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<ChapterEntity> Chapters { get; set; }
        [Required]
        public List<AuthorBookEntity> AuthorBooks { get; set; }

        public BookEntity()
        {
            Chapters = new List<ChapterEntity>();
            AuthorBooks = new List<AuthorBookEntity>();
        }
    }
}