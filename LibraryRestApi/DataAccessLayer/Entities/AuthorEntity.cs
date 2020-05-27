using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LibraryRestApi.DataAccessLayer.Entities
{
    public class AuthorEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public List<AuthorBookEntity> AuthorBooks { get; set; }

        public AuthorEntity()
        {
            AuthorBooks = new List<AuthorBookEntity>();
        }
    }
}