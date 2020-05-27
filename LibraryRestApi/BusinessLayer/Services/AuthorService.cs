using AutoMapper;
using LibraryRestApi.BusinessLayer.Models;
using LibraryRestApi.DataAccessLayer;
using LibraryRestApi.DataAccessLayer.Entities;
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

        public void Create(Author author)
        {
            _unitOfWork.AuthorRepository.Create(_mapper.Map<AuthorEntity>(author));
            _unitOfWork.SaveChanges();
        }

        public Author Read(int id)
        {
            return _mapper.Map<Author>(_unitOfWork.AuthorRepository.Read(id));
        }

        public void Update(Author author)
        {
            _unitOfWork.AuthorRepository.Update(_mapper.Map<AuthorEntity>(author));
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _unitOfWork.AuthorRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<Author> GetAll()
        {
            var authors = _unitOfWork.AuthorRepository.GetAll();
            return authors.Select(authorEntity => _mapper.Map<Author>(authorEntity));
        }
    }
}
