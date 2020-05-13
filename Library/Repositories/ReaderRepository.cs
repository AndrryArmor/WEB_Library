using Library.Entities;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class ReaderRepository : IRepository<Reader>
    {
        private DbSet<Reader> _readers;

        public ReaderRepository(DbContext dbContext)
        {
            _readers = dbContext.Set<Reader>();
        }

        public void Create(Reader item)
        {
            _readers.Add(item);
        }

        public Reader Read(int id)
        {
            return _readers.Find(id);
        }

        public void Update(Reader item)
        {
            _readers.Update(item);
        }

        public void Delete(int id)
        {
            _readers.Remove(_readers.Find(id));
        }

        public IEnumerable<Reader> GetAll()
        {
            return _readers;
        }
    }
}
