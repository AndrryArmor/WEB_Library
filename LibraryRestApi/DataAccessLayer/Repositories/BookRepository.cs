using Library.Entities;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class BookRepository : Repository<BookEntity, int>, IBookRepository
    {
        public BookRepository(LibraryContext libraryContext) : base(libraryContext) { }
    }
}
