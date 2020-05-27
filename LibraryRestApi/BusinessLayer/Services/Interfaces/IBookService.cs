using LibraryRestApi.BusinessLayer.Models;
using LibraryRestApi.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace LibraryRestApi.BusinessLayer.Services
{
    public interface IBookService
    {
        IEnumerable<Book> FindByAuthorName(string authorName);
        IEnumerable<Book> FindByName(string name);
        IEnumerable<Book> FindByChapterName(string chapterName);
    }
}