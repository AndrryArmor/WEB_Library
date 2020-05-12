using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private IUnitOfWork unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Book> FindByAuthorName(string authorName)
        {
            var authors = new List<Author>(unitOfWork.AuthorRepository.GetAll());
            var author = authors.Find(author => author.Name.ToLower() == authorName?.ToLower() ||
                                                author.Surname.ToLower() == authorName?.ToLower() ||
                                                author.Name.ToLower() + " " + author.Surname.ToLower() == authorName?.ToLower());
            return author?.AuthorBooks.Select(authorBook => authorBook.Book);
        }

        public IEnumerable<Book> FindByName(string name)
        {
            var books = new List<Book>(unitOfWork.BookRepository.GetAll());
            return books.FindAll(book => book.Name == name);
        } 

        public IEnumerable<Book> FindByChapterName(string chapterName)
        {
            var books = new List<Book>(unitOfWork.BookRepository.GetAll());
            var chapters = books.SelectMany(book => book.Chapters)
                                .Where(chapter => chapter.Name == chapterName);
            return chapters.Select(chapter => chapter.Book);
        }
    }
}
