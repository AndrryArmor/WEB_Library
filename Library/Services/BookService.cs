using AutoMapper;
using Library.Data.Entities;
using Library.Models;
using Library.Objects;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
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

        public IEnumerable<BookDTO> FindByAuthorName(string authorName)
        {
            var authors = new List<Author>(_unitOfWork.AuthorRepository.GetAll());
            var author = authors.Find(author => author.Name.ToLower() == authorName?.ToLower() ||
                                                author.Surname.ToLower() == authorName?.ToLower() ||
                                                author.Name.ToLower() + " " + author.Surname.ToLower() == authorName?.ToLower());
            var foundBooks = author?.AuthorBooks.Select(authorBook => authorBook.Book);
            return foundBooks.Select(book => _mapper.Map<BookDTO>(book));
        }

        public IEnumerable<BookDTO> FindByName(string name)
        {
            var books = new List<Book>(_unitOfWork.BookRepository.GetAll());
            var foundBooks = books.FindAll(book => book.Name == name);
            return foundBooks.Select(book => _mapper.Map<BookDTO>(book));
        } 

        public IEnumerable<BookDTO> FindByChapterName(string chapterName)
        {
            var books = new List<Book>(_unitOfWork.BookRepository.GetAll());
            var chapters = books.SelectMany(book => book.Chapters)
                                .Where(chapter => chapter.Name == chapterName);
            var foundBooks = chapters.Select(chapter => chapter.Book);
            return foundBooks.Select(book => _mapper.Map<BookDTO>(book));
        }
    }
}
