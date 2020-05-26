using Library.Models;
using Library.Objects;
using System;
using System.Collections.Generic;

namespace Library.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> FindByName(string name);
        IEnumerable<Author> FindByBirthDate(DateTime birthDate);
        IEnumerable<Author> FindByBookCount(int bookCount);
    }
}