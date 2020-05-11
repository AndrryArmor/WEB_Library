using System.Security.Policy;

namespace Library.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Book Book { get; set; }
    }
}