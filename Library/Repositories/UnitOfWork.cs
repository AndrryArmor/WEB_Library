using Library.Entities;
using Library.Models;
using Microsoft.AspNetCore.Identity;
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

        public SignInManager<User> SignInManager { get; }
        public UserManager<User> UserManager { get; }
        public IReaderRepository ReaderRepository { get; }
        public IReaderCardRepository ReaderCardRepository { get; }
        public IRecordRepository RecordRepository { get; }
        public IBookRepository BookRepository { get; }
        public IChapterRepository ChapterRepository { get; }
        public IAuthorBookRepository AuthorBookRepository { get; }
        public IAuthorRepository AuthorRepository { get; }

        public UnitOfWork(LibraryContext libraryContext, SignInManager<User> signInManager, UserManager<User> userManager,
            IReaderRepository readerRepository, IReaderCardRepository readerCardRepository, IRecordRepository recordRepository, 
            IBookRepository bookRepository, IChapterRepository chapterRepository, IAuthorBookRepository authorBookRepository,
            IAuthorRepository authorRepository)
        {
            _libraryContext = libraryContext;
            SignInManager = signInManager;
            UserManager = userManager;
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
