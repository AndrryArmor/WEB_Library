using System;
using System.Diagnostics.Eventing.Reader;

namespace Library.Objects
{
    public class RecordDTO
    {
        public int Id { get; set; }
        public BookDTO Book { get; set; }
        public DateTime DateOfReceiving { get; set; }
        public ReaderDTO Reader { get; set; }

        public RecordDTO(int id, BookDTO book, DateTime dateOfReceiving, ReaderDTO reader)
        {
            Id = id;
            Book = book;
            DateOfReceiving = dateOfReceiving;
            Reader = reader;
        }
    }
}