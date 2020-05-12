namespace Library.Data.Entities
{
    public class AuthorBook
    {
        public int Id { get; set; }
        public Author Author { get; set; }
        public Book Book { get; set; } 
    }
}