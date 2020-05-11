using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class AuthorService
    {
        private UnitOfWork unitOfWork;

        public AuthorService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Author> FindByName(string name)
        {
            return unitOfWork.AuthorRepository.GetAll().Where(author => author.Name == name);
        }

        public IEnumerable<Author> FindByBirthDate(DateTime birthDate)
        {
            return unitOfWork.AuthorRepository.GetAll().Where(author => author.BirthDate == birthDate);
        }

        public IEnumerable<Author> FindByBookCount(int bookCount)
        {
            var authors = new List<Author>(unitOfWork.AuthorRepository.GetAll());
            return authors.FindAll(author => author.AuthorBooks.Count == bookCount);
        }
    }
}
