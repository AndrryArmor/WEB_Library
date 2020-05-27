using LibraryRestApi.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryRestApi.DataAccessLayer.Repositories
{
    public class BookRepository : Repository<BookEntity, int>, IBookRepository
    {
        public BookRepository(LibraryContext libraryContext) : base(libraryContext) { }
    }
}
