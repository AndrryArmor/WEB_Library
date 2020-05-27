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
    public class AuthorsController : Controller
    {
        private IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;    
        }

        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _authorService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            var author = _authorService.Read(id);
            if (author == null)
                return NotFound();
            return new ObjectResult(author);
        }

        [HttpPost]
        public ActionResult<Author> Post([FromBody] Author author)
        {
            if (author == null)
                return BadRequest();
            _authorService.Create(author);
            return Ok(author);
        }

        [HttpPut("{id}")]
        public ActionResult<Author> Put([FromBody] Author author, int id)
        {
            if (author == null)
                return BadRequest();
            if (_authorService.Read(id) == null)
                return NotFound();

            author.Id = id;
            _authorService.Update(author);
            return Ok(author);
        }

        [HttpDelete("{id}")]
        public ActionResult<Author> Delete(int id)
        {
            var author = _authorService.Read(id);
            if (author == null)
                return NotFound();
            _authorService.Delete(id);
            return Ok(author);
        }
    }
}
