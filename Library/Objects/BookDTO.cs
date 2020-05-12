using System.Collections;
using System.Collections.Generic;

namespace Library.Objects
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ChapterDTO> Chapters { get; set; }
        public List<AuthorDTO> Authors { get; set; }

        public BookDTO()
        {
            Chapters = new List<ChapterDTO>();
            Authors = new List<AuthorDTO>();
        }
    }
}