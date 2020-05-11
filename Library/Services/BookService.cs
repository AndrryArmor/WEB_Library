using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookService
    {
        private UnitOfWork unitOfWork;

        public BookService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Book> FindByAuthor(string authorToFind)
        {
            var authors = new List<Author>(unitOfWork.AuthorRepository.GetAll());
            var author = authors.Find(author => author.Name.ToLower() == authorToFind.ToLower() ||
                                      author.Surname.ToLower() == authorToFind.ToLower() ||
                                      author.Name.ToLower() + author.Surname.ToLower() == authorToFind.ToLower());
            return author?.AuthorBooks.Select(authorBook => authorBook.Book);
        }

        public IEnumerable<Book> FindByName(string nameToFind)
        {
            var books = new List<Book>(unitOfWork.BookRepository.GetAll());
            return books.FindAll(book => book.Name == nameToFind);
        } 

        public IEnumerable<Book> FindByChapterName(string chapterNameToFind)
        {
            var books = new List<Book>(unitOfWork.BookRepository.GetAll());
            var chapters = books.SelectMany(book => book.Chapters)
                                .Where(chapter => chapter.Name == chapterNameToFind);
            return chapters.Select(chapter => chapter.Book);
        }
    }
}
