using LibraryRestApi.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryRestApi.DataAccessLayer
{
    public interface IUnitOfWork
    {
        IReaderRepository ReaderRepository { get; }
        IReaderCardRepository ReaderCardRepository { get; }
        IRecordRepository RecordRepository { get; }
        IBookRepository BookRepository { get; }
        IChapterRepository ChapterRepository { get; }
        IAuthorBookRepository AuthorBookRepository { get; }
        IAuthorRepository AuthorRepository { get; }

        void SaveChanges();
    }
}
