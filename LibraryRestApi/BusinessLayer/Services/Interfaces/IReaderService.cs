using LibraryRestApi.BusinessLayer.Models;
using LibraryRestApi.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace LibraryRestApi.BusinessLayer.Services
{
    public interface IReaderService
    {
        void Create(Reader item);
        Reader Read(int id);
        void Update(Reader item);
        void Delete(int id);
        IEnumerable<Reader> GetAll();
    }
}