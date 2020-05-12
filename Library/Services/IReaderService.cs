using Library.Models;
using Library.Objects;
using System;
using System.Collections.Generic;

namespace Library.Services
{
    public interface IReaderService
    {
        IEnumerable<ReaderDTO> GetAllReaders();
        void AddNewReader(string name, string surname, int age, string email);
        void AddBookToReader(int readerId, int bookId);
    }
}