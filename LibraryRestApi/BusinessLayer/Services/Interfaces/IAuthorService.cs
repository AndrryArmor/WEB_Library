using LibraryRestApi.BusinessLayer.Models;
using LibraryRestApi.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace LibraryRestApi.BusinessLayer.Services
{
    public interface IAuthorService
    {
        void Create(Author item);
        Author Read(int id);
        void Update(Author item);
        void Delete(int id);
        IEnumerable<Author> GetAll();
    }
}