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

        public IReaderRepository ReaderRepository { get; }
        public IBookRepository BookRepository { get; }
        public IAuthorRepository AuthorRepository { get; }

        public UnitOfWork(DbContext dbContext, IReaderRepository readerRepository,
            IBookRepository bookRepository, IAuthorRepository authorRepository)
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
