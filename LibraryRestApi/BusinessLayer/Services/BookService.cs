using AutoMapper;
using LibraryRestApi.BusinessLayer.Models;
using LibraryRestApi.DataAccessLayer;
using LibraryRestApi.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace LibraryRestApi.BusinessLayer.Services
{
    public class BookService : IBookService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(Book book)
        {
            _unitOfWork.BookRepository.Create(_mapper.Map<BookEntity>(book));
            _unitOfWork.SaveChanges();
        }

        public Book Read(int id)
        {
            return _mapper.Map<Book>(_unitOfWork.BookRepository.Read(id));
        }

        public void Update(Book book)
        {
            _unitOfWork.BookRepository.Update(_mapper.Map<BookEntity>(book));
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _unitOfWork.BookRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<Book> GetAll()
        {
            var books = _unitOfWork.BookRepository.GetAll();
            return books.Select(bookEntity => _mapper.Map<Book>(bookEntity));
        }
    }
}
