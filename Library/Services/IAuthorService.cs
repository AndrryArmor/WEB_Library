using Library.Models;
using Library.Objects;
using System;
using System.Collections.Generic;

namespace Library.Services
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDTO> FindByName(string name);
        IEnumerable<AuthorDTO> FindByBirthDate(DateTime birthDate);
        IEnumerable<AuthorDTO> FindByBookCount(int bookCount);
    }
}