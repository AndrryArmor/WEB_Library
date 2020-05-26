using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Objects
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

        public Reader(int id, ReaderCard readerCard)
        {
            Id = id;
            ReaderCard = readerCard;
            Records = new List<Record>();
        }
    }
}
