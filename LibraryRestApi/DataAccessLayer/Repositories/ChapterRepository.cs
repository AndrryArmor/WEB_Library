using LibraryRestApi.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryRestApi.DataAccessLayer.Repositories
{
    public class ChapterRepository : Repository<ChapterEntity, int>, IChapterRepository
    {
        public ChapterRepository(LibraryContext libraryContext) : base(libraryContext) { }
    }
}
