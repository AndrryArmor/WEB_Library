using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class Reader
    {
        public int Id { get; set; }
        public ReaderCard ReaderCard { get; set; }
        public List<Record> Records { get; set; }

        public Reader()
        {
            Records = new List<Record>();
        }
    }
}
