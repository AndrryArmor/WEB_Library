using AutoMapper;
using Library.Entities;
using Library.Models;
using Library.Objects;
using Library.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public IEnumerable<Book> FindByAuthorName(string authorName)
        {
            var books = _unitOfWork.BookRepository.GetAll()
                .Include(book => book.AuthorBooks)
                .ThenInclude(authorBook => authorBook.Author).ToList();
            var foundBooks = new List<BookEntity>();

            foreach (var book in books)
            {
                var foundAuthorMatch = book.AuthorBooks
                    .Find(authorBook => authorBook.Author.Name.ToLower() == authorName.ToLower() ||
                        authorBook.Author.Surname.ToLower() == authorName.ToLower() ||
                        authorBook.Author.Name.ToLower() + " " + authorBook.Author.Surname.ToLower() == authorName.ToLower());
                if (foundAuthorMatch != null)
                    foundBooks.Add(book);
            }
            return foundBooks.Select(book => _mapper.Map<Book>(book));
        }

        public IEnumerable<Book> FindByName(string name)
        {
            var foundBooks = _unitOfWork.BookRepository.GetAll()
                .Where(book => book.Name == name);
            return foundBooks.Select(book => _mapper.Map<Book>(book));
        } 

        public IEnumerable<Book> FindByChapterName(string chapterName)
        {
            var foundBooks = _unitOfWork.BookRepository.GetAll()
                .Include(book => book.Chapters)
                .AsEnumerable()
                .Where(book => book.Chapters
                    .Find(chapter => chapter.Name == chapterName) != null);
            return foundBooks.Select(book => _mapper.Map<Book>(book));
        }
    }
}
