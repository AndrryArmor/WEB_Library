using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryRestApi.DataAccessLayer.Entities
{
    public class ReaderEntity
    {
        public int Id { get; set; }
        [Required]
        public ReaderCardEntity ReaderCard { get; set; }
        [Required]
        public List<RecordEntity> Records { get; set; }

        public ReaderEntity()
        {
            Records = new List<RecordEntity>();
        }
    }
}
