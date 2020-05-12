using Library.Data;
using Library.Data.Entities;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private List<Book> books;

        public BookRepository()
        {
            DataSource.CreateData();
            books = DataSource.Books;
        }

        public void Create(Book item)
        {
            books.Add(item);
        }

        public Book Read(int id)
        {
            return books.Find(book => book.Id == id);
        }

        public void Update(Book item)
        {
            Book foundBook = books.Find(book => book.Id == item.Id);
            if (foundBook != null)
                books.Remove(foundBook);
            books.Add(item);
        }

        public void Delete(int id)
        {
            books.RemoveAll(book => book.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return books;
        }
    }
}
