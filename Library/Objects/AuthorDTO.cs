using System;
using System.Collections.Generic;

namespace Library.Objects
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public List<BookDTO> Books { get; set; }

        public AuthorDTO()
        {
            Books = new List<BookDTO>();
        }
    }
}