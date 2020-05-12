using System;
using System.Collections.Generic;

namespace Library.Data.Entities
{
    public class ReaderCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}