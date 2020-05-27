using LibraryRestApi.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryRestApi.DataAccessLayer.Repositories
{
    public class ReaderCardRepository : Repository<ReaderCardEntity, int>, IReaderCardRepository
    {
        public ReaderCardRepository(LibraryContext libraryContext) : base(libraryContext) { }
    }
}
