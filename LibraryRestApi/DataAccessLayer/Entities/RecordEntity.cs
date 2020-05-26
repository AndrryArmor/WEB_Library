using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Eventing.Reader;

namespace Library.Entities
{
    public class RecordEntity
    {
        public int Id { get; set; }
        [Required]
        public BookEntity Book { get; set; }
        [Required]
        public DateTime DateOfReceiving { get; set; }
        [Required]
        public ReaderEntity Reader { get; set; }
    }
}