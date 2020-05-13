using Library.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Reader> ReaderRepository { get; }
        IRepository<Book> BookRepository { get; }
        IRepository<Author> AuthorRepository { get; }
        void SaveChanges();
    }
}
