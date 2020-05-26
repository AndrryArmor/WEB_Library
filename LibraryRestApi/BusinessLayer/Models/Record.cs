using System;
using System.Diagnostics.Eventing.Reader;

namespace Library.Objects
{
    public class Record
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public DateTime DateOfReceiving { get; set; }
        public Reader Reader { get; set; }

        public Record(int id, Book book, DateTime dateOfReceiving, Reader reader)
        {
            Id = id;
            Book = book;
            DateOfReceiving = dateOfReceiving;
            Reader = reader;
        }
    }
}