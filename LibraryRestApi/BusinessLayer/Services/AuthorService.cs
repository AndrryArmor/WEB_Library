using AutoMapper;
using LibraryRestApi.BusinessLayer.Models;
using LibraryRestApi.DataAccessLayer;
using LibraryRestApi.DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryRestApi.BusinessLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private IMapper _mapper; 
        private IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<Author> FindByName(string name)
        {
            var foundAuthors = _unitOfWork.AuthorRepository.GetAll()
                .Include(author => author.AuthorBooks)
                .Where(author => author.Name.ToLower() == name.ToLower() ||
                                 author.Surname.ToLower() == name.ToLower() ||
                                 author.Name.ToLower() + " " + author.Surname.ToLower() == name.ToLower());
            return foundAuthors.Select(author => _mapper.Map<Author>(author));
        }

        public IEnumerable<Author> FindByBirthDate(DateTime birthDate)
        {
            var foundAuthors = _unitOfWork.AuthorRepository.GetAll()
                .Include(author => author.AuthorBooks)
                .Where(author => author.BirthDate == birthDate);
            return foundAuthors.Select(author => _mapper.Map<Author>(author));
        }

        public IEnumerable<Author> FindByBookCount(int bookCount)
        {
            var foundAuthors = _unitOfWork.AuthorRepository.GetAll()
                .Include(author => author.AuthorBooks)
                .Where(author => author.AuthorBooks.Count == bookCount);

            return foundAuthors.Select(author => _mapper.Map<Author>(author));
        }
    }
}
