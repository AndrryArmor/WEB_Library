using Library.Data.Entities;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Reader> ReaderRepository { get; }
        public IRepository<Book> BookRepository { get; }
        public IRepository<Author> AuthorRepository { get; }

        public UnitOfWork(IRepository<Reader> readerRepository, IRepository<Book> bookRepository, IRepository<Author> authorRepository)
        {
            ReaderRepository = readerRepository;
            BookRepository = bookRepository;
            AuthorRepository = authorRepository;
        }
    }
}
