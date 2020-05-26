using Library.Entities;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class RecordRepository : Repository<RecordEntity, int>, IRecordRepository
    {
        public RecordRepository(LibraryContext libraryContext) : base(libraryContext) { }
    }
}
