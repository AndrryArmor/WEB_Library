using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        private List<Author> authors;

        public AuthorRepository()
        {
            DataSource.CreateData();
            authors = DataSource.Authors;
        }

        public void Create(Author item)
        {
            authors.Add(item);
        }

        public Author Read(int id)
        {
            return authors.Find(author => author.Id == id);
        }

        public void Update(Author item)
        {
            Author foundAuthor = authors.Find(author => author.Id == item.Id);
            if (foundAuthor != null)
                authors.Remove(foundAuthor);
            authors.Add(item);
        }

        public void Delete(int id)
        {
            authors.RemoveAll(book => book.Id == id);
        }

        public IEnumerable<Author> GetAll()
        {
            return authors;
        }
    }
}
