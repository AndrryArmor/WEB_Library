using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Author> FindByName(string name)
        {
            return unitOfWork.AuthorRepository.GetAll()
                .Where(author => author.Name.ToLower() == name?.ToLower() ||
                                 author.Surname.ToLower() == name?.ToLower() ||
                                 author.Name.ToLower() + " " + author.Surname.ToLower() == name?.ToLower());
        }

        public IEnumerable<Author> FindByBirthDate(DateTime birthDate)
        {
            return unitOfWork.AuthorRepository.GetAll()
                .Where(author => author.BirthDate == birthDate);
        }

        public IEnumerable<Author> FindByBookCount(int bookCount)
        {
            var authors = new List<Author>(unitOfWork.AuthorRepository.GetAll());
            return authors.FindAll(author => author.AuthorBooks.Count == bookCount);
        }
    }
}
