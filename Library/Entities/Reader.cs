using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class Reader
    {
        public int Id { get; set; }
        [Required]
        public ReaderCard ReaderCard { get; set; }
        [Required]
        public List<Record> Records { get; set; }

        public Reader()
        {
            Records = new List<Record>();
        }
    }
}
