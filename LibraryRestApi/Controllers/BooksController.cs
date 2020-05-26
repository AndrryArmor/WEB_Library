using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Library.Models;
using Library.Services;
using Library.Objects;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult FindBooks()
        {
            ViewData["Visibility"] = "hidden";
            return View();
        }

        [HttpPost]
        public IActionResult FindBooks(string query, string findType)
        {
            IEnumerable<BookDTO> books = string.IsNullOrEmpty(query) == false
                ? GetBooksByQuery(query, findType)
                : new List<BookDTO>();

            ViewData["Visibility"] = "";
            return View(books);
        }

        private IEnumerable<BookDTO> GetBooksByQuery(string query, string findType)
        {
            switch (findType)
            {
                case "name":
                    return _bookService.FindByName(query);
                case "authorName":
                    return _bookService.FindByAuthorName(query);
                case "chapterName":
                    return _bookService.FindByChapterName(query);
                default:
                    return null;
            }
        }
    }
}
