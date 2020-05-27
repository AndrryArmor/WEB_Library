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
        private IAccountService _authorService;

        public AuthorsController(IAccountService authorService)
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
            IEnumerable<AuthorDTO> authors = string.IsNullOrEmpty(query) == false
                ? GetAuthorsByQuery(query, findType)
                : new List<AuthorDTO>();

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
                    return DateTime.TryParse(query, out DateTime date) == true
                        ? _authorService.FindByBirthDate(date)
                        : new List<AuthorDTO>();
                case "bookCount":
                    return int.TryParse(query, out int bookCount) == true
                        ? _authorService.FindByBookCount(bookCount)
                        : new List<AuthorDTO>();
                default:
                    return new List<AuthorDTO>();
            }
        }
    }
}
