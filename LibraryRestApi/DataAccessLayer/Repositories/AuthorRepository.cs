using LibraryRestApi.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryRestApi.DataAccessLayer.Repositories
{
    public class AuthorRepository : Repository<AuthorEntity, int>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext libraryContext) : base(libraryContext) { }
    }
}
