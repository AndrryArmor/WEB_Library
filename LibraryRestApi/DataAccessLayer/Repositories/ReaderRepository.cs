using LibraryRestApi.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryRestApi.DataAccessLayer.Repositories
{
    public class ReaderRepository : Repository<ReaderEntity, int>, IReaderRepository
    {
        public ReaderRepository(LibraryContext libraryContext) : base(libraryContext) { }
    }
}
