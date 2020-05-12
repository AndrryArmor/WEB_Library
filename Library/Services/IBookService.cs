using Library.Models;
using System;
using System.Collections.Generic;

namespace Library.Services
{
    public interface IBookService
    {
        IEnumerable<Book> FindByAuthorName(string authorName);
        IEnumerable<Book> FindByName(string name);
        IEnumerable<Book> FindByChapterName(string chapterName);
    }
}