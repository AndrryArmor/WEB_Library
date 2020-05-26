using Library.Models;
using Library.Objects;
using System;
using System.Collections.Generic;

namespace Library.Services
{
    public interface IBookService
    {
        IEnumerable<BookDTO> FindByAuthorName(string authorName);
        IEnumerable<BookDTO> FindByName(string name);
        IEnumerable<BookDTO> FindByChapterName(string chapterName);
    }
}