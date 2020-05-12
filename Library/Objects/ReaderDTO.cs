using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Objects
{
    public class ReaderDTO
    {
        public int Id { get; set; }
        public ReaderCardDTO ReaderCard { get; set; }
        public List<RecordDTO> Records { get; set; }

        public ReaderDTO()
        {
            Records = new List<RecordDTO>();
        }

        public ReaderDTO(int id, ReaderCardDTO readerCard)
        {
            Id = id;
            ReaderCard = readerCard;
            Records = new List<RecordDTO>();
        }
    }
}
