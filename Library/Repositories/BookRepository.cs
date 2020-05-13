using Library.Entities;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private DbSet<Book> _books;

        public BookRepository(DbContext dbContext)
        {
            _books = dbContext.Set<Book>();
        }

        public void Create(Book item)
        {
            _books.Add(item);
        }

        public Book Read(int id)
        {
            return _books.Find(id);
        }

        public void Update(Book item)
        {
            _books.Update(item);
        }

        public void Delete(int id)
        {
            _books.Remove(_books.Find(id));
        }

        public IEnumerable<Book> GetAll()
        {
            return _books;
        }
    }
}
