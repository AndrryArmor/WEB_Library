using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class ReaderViewModel
    {
        public IEnumerable<Reader> Readers { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Record> Records { get; set; }
    }
}
