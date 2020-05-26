using Library.Entities;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private LibraryContext _libraryContext; 

        public IReaderRepository ReaderRepository { get; }
        public IReaderCardRepository ReaderCardRepository { get; }
        public IRecordRepository RecordRepository { get; }
        public IBookRepository BookRepository { get; }
        public IChapterRepository ChapterRepository { get; }
        public IAuthorBookRepository AuthorBookRepository { get; }
        public IAuthorRepository AuthorRepository { get; }

        public UnitOfWork(LibraryContext libraryContext, IReaderRepository readerRepository, 
            IReaderCardRepository readerCardRepository, IRecordRepository recordRepository, 
            IBookRepository bookRepository, IChapterRepository chapterRepository,
            IAuthorBookRepository authorBookRepository, IAuthorRepository authorRepository)
        {
            _libraryContext = libraryContext;
            ReaderRepository = readerRepository;
            ReaderCardRepository = readerCardRepository;
            RecordRepository = recordRepository;
            BookRepository = bookRepository;
            ChapterRepository = chapterRepository;
            AuthorBookRepository = authorBookRepository;
            AuthorRepository = authorRepository;
        }

        public void SaveChanges()
        {
            _libraryContext.SaveChanges();
        }
    }
}
