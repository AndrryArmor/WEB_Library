using LibraryRestApi.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryRestApi.DataAccessLayer.Repositories
{
    public class AuthorBookRepository : Repository<AuthorBookEntity, int>, IAuthorBookRepository
    {
        public AuthorBookRepository(LibraryContext libraryContext) : base(libraryContext) { }
    }
}
