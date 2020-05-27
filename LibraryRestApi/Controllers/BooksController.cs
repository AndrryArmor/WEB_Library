using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibraryRestApi.BusinessLayer.Services;
using LibraryRestApi.BusinessLayer.Models;

namespace LibraryRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _bookService.Read(id);
            if (book == null)
                return NotFound();
            return new ObjectResult(book);
        }

        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();
            _bookService.Create(book);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public ActionResult<Book> Put([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();
            if (_bookService.Read(book.Id) == null)
                return NotFound();

            _bookService.Update(book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            var book = _bookService.Read(id);
            if (book == null)
                return NotFound();
            _bookService.Delete(id);
            return Ok(book);
        }
    }
}
