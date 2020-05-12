using Library.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class ReaderViewModel
    {
        public IEnumerable<ReaderDTO> Readers { get; set; }
        public IEnumerable<BookDTO> Books { get; set; }
        public IEnumerable<RecordDTO> Records { get; set; }
    }
}
