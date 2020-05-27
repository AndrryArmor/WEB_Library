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
    public class ReadersController : Controller
    {
        private IReaderService _readerService;

        public ReadersController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        [HttpGet]
        public IEnumerable<Reader> Get()
        {
            return _readerService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Reader> Get(int id)
        {
            var reader = _readerService.Read(id);
            if (reader == null)
                return NotFound();
            return new ObjectResult(reader);
        }

        [HttpPost()]
        public ActionResult<Reader> Post([FromBody] Reader reader)
        {
            if (reader == null)
                return BadRequest();
            _readerService.Create(reader);
            return Ok(reader);
        }

        [HttpPut("{id}")]
        public ActionResult<Reader> Put([FromBody] Reader reader)
        {
            if (reader == null)
                return BadRequest();
            if (_readerService.Read(reader.Id) == null)
                return NotFound();

            _readerService.Update(reader);
            return Ok(reader);
        }

        [HttpDelete("{id}")]
        public ActionResult<Reader> Delete(int id)
        {
            var reader = _readerService.Read(id);
            if (reader == null)
                return NotFound();
            _readerService.Delete(id);
            return Ok(reader);
        }
    }
}
