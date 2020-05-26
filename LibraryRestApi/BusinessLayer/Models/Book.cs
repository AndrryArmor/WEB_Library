using System.Collections;
using System.Collections.Generic;

namespace Library.Objects
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Chapter> Chapters { get; set; }
        public List<Author> Authors { get; set; }

        public Book()
        {
            Chapters = new List<Chapter>();
            Authors = new List<Author>();
        }
    }
}