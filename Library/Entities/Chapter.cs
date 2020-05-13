using System.Diagnostics.CodeAnalysis;
using System.Security.Policy;

namespace Library.Entities
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Book Book { get; set; }
    }
}