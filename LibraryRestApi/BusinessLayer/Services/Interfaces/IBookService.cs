using LibraryRestApi.BusinessLayer.Models;
using LibraryRestApi.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace LibraryRestApi.BusinessLayer.Services
{
    public interface IBookService
    {
        void Create(Book item);
        Book Read(int id);
        void Update(Book item);
        void Delete(int id);
        IEnumerable<Book> GetAll();
    }
}