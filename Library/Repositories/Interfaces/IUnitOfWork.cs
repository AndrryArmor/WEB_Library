using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Library.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Library.Repositories
{
    public interface IUnitOfWork
    {
        SignInManager<User> SignInManager { get; }
        UserManager<User> UserManager { get; }

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
