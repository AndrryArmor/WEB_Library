using Library.Entities;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext; 
        public IRepository<Reader> ReaderRepository { get; }
        public IRepository<Book> BookRepository { get; }
        public IRepository<Author> AuthorRepository { get; }

        public UnitOfWork(DbContext dbContext, IRepository<Reader> readerRepository, IRepository<Book> bookRepository, IRepository<Author> authorRepository)
        {
            _dbContext = dbContext;
            ReaderRepository = readerRepository;
            BookRepository = bookRepository;
            AuthorRepository = authorRepository;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
