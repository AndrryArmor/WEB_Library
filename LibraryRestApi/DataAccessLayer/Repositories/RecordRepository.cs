using LibraryRestApi.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryRestApi.DataAccessLayer.Repositories
{
    public class RecordRepository : Repository<RecordEntity, int>, IRecordRepository
    {
        public RecordRepository(LibraryContext libraryContext) : base(libraryContext) { }
    }
}
