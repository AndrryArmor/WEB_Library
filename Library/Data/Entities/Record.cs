using System;
using System.Diagnostics.Eventing.Reader;

namespace Library.Data.Entities
{
    public class Record
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public DateTime DateOfReceiving { get; set; }
        public Reader Reader { get; set; }
    }
}