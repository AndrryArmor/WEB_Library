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
    public class AuthorsController : Controller
    {
        private IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;    
        }

        [HttpGet]
        public IActionResult FindAuthors()
        {
            ViewData["Visibility"] = "hidden";
            return View();
        }

        [HttpPost]
        public IActionResult FindAuthors(string query, string findType)
        {
            IEnumerable<AuthorDTO> authors = GetAuthorsByQuery(query, findType);
            ViewData["Visibility"] = "";
            return View(authors);
        }

        private IEnumerable<AuthorDTO> GetAuthorsByQuery(string query, string findType)
        {
            switch (findType)
            {
                case "name":
                    return _authorService.FindByName(query);
                case "birthDate":
                    DateTime.TryParse(query, out DateTime date);
                    return _authorService.FindByBirthDate(date);
                case "bookCount":
                    int.TryParse(query, out int bookCount);
                    return _authorService.FindByBookCount(bookCount);
                default:
                    return null;
            }
        }
    }
}
