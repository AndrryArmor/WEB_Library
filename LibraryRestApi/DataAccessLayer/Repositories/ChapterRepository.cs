using Library.Entities;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class ChapterRepository : Repository<ChapterEntity, int>, IChapterRepository
    {
        public ChapterRepository(LibraryContext libraryContext) : base(libraryContext) { }
    }
}
