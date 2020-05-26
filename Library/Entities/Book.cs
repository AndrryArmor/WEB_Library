using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Library.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Chapter> Chapters { get; set; }
        [Required]
        public List<AuthorBook> AuthorBooks { get; set; }

        public Book()
        {
            Chapters = new List<Chapter>();
            AuthorBooks = new List<AuthorBook>();
        }
    }
}