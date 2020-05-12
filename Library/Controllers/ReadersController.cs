using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Library.Models;
using Library.Services;

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
            IEnumerable<Reader> readers = _readerService.GetAllReaders();
            return View("RegisterNewReader", readers);
        }

        [HttpPost]
        public IActionResult RegisterNewReader(string name, string surname, int age, string email)
        {
            _readerService.AddNewReader(name, surname, age, email);
            IEnumerable<Reader> readers = _readerService.GetAllReaders();
            return View("RegisterNewReader", readers);
        }

        [HttpGet]
        public IActionResult TakeABook()
        {
            var readerViewModel = new ReaderViewModel()
            {
                Readers = _readerService.GetAllReaders(),
                Books = _readerService.GetAllBooks(),
                Records = _readerService.GetAllReaders().SelectMany(reader => reader.Records).ToList()
            };
            return View("TakeABook", readerViewModel);
        }

        [HttpPost]
        public IActionResult TakeABook(string readerId, string bookId)
        {
            IEnumerable<Reader> readers = _readerService.GetAllReaders();
            IEnumerable<Record> records = readers.SelectMany(reader => reader.Records);
            IEnumerable<Book> books = records.Select(record => record.Book).ToHashSet();
            var readerViewModel = new ReaderViewModel()
            {
                Readers = readers,
                Records = records,
                Books = books,
            };

            _readerService.AddBookToReader(int.Parse(readerId), int.Parse(bookId));
            return View("TakeABook", readerViewModel);
        }
    }
}
