using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Eventing.Reader;

namespace Library.Entities
{
    public class Record
    {
        public int Id { get; set; }
        [Required]
        public Book Book { get; set; }
        [Required]
        public DateTime DateOfReceiving { get; set; }
        [Required]
        public Reader Reader { get; set; }
    }
}