using System.Security.Policy;

namespace Library.Objects
{
    public class ChapterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BookDTO Book { get; set; }
    }
}