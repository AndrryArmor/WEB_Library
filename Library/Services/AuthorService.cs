﻿using AutoMapper;
using Library.Data.Entities;
using Library.Models;
using Library.Objects;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
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

        public IEnumerable<AuthorDTO> FindByName(string name)
        {
            var foundAuthors = _unitOfWork.AuthorRepository.GetAll()
                .Where(author => author.Name.ToLower() == name?.ToLower() ||
                                 author.Surname.ToLower() == name?.ToLower() ||
                                 author.Name.ToLower() + " " + author.Surname.ToLower() == name?.ToLower());
            return foundAuthors.Select(author => _mapper.Map<AuthorDTO>(author));
        }

        public IEnumerable<AuthorDTO> FindByBirthDate(DateTime birthDate)
        {
            var foundAuthors = _unitOfWork.AuthorRepository.GetAll()
                .Where(author => author.BirthDate == birthDate);
            return foundAuthors.Select(author => _mapper.Map<AuthorDTO>(author));
        }

        public IEnumerable<AuthorDTO> FindByBookCount(int bookCount)
        {
            var authors = new List<Author>(_unitOfWork.AuthorRepository.GetAll());
            var foundAuthors = authors.FindAll(author => author.AuthorBooks.Count == bookCount);
            return foundAuthors.Select(author => _mapper.Map<AuthorDTO>(author));
        }
    }
}