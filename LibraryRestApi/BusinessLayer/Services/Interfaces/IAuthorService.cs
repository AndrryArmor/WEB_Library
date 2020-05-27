using LibraryRestApi.BusinessLayer.Models;
using LibraryRestApi.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace LibraryRestApi.BusinessLayer.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> FindByName(string name);
        IEnumerable<Author> FindByBirthDate(DateTime birthDate);
        IEnumerable<Author> FindByBookCount(int bookCount);
    }
}