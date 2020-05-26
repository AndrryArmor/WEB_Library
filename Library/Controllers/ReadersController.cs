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
    public class ReadersController : Controller
    {
        private IReaderService _readerService;

        public ReadersController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        [HttpGet]
        public IActionResult RegisterNewReader()
        {
            IEnumerable<ReaderDTO> readers = _readerService.GetAllReaders();
            return View("RegisterNewReader", readers);
        }

        [HttpPost]
        public IActionResult RegisterNewReader(string name, string surname, int age, string email)
        {
            _readerService.AddNewReader(name, surname, age, email);
            IEnumerable<ReaderDTO> readers = _readerService.GetAllReaders();
            return View("RegisterNewReader", readers);
        }

        [HttpGet]
        public IActionResult TakeABook()
        {
            var readerViewModel = new ReaderViewModel()
            {
                Readers = _readerService.GetAllReaders(),
                Records = _readerService.GetAllRecords(),
                Books = _readerService.GetAllBooks()
            };
            return View("TakeABook", readerViewModel);
        }

        [HttpPost]
        public IActionResult TakeABook(string readerId, string bookId)
        {
            _readerService.AddBookToReader(int.Parse(readerId), int.Parse(bookId));

            var readerViewModel = new ReaderViewModel()
            {
                Readers = _readerService.GetAllReaders(),
                Records = _readerService.GetAllRecords(),
                Books = _readerService.GetAllBooks()
            };
            return View("TakeABook", readerViewModel);
        }
    }
}
