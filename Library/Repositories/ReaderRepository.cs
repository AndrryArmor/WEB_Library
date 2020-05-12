using Library.Entities;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class ReaderRepository : IRepository<Reader>
    {
        private List<Reader> readers;

        public ReaderRepository()
        {
            DataSource.CreateData();
            readers = DataSource.Readers;
        }

        public void Create(Reader item)
        {
            readers.Add(item);
        }

        public Reader Read(int id)
        {
            return readers.Find(reader => reader.Id == id);
        }

        public void Update(Reader item)
        {
            Reader foundReader = readers.Find(reader => reader.Id == item.Id);
            if (foundReader != null)
                readers.Remove(foundReader);
            readers.Add(item);
        }

        public void Delete(int id)
        {
            readers.RemoveAll(reader => reader.Id == id);
        }

        public IEnumerable<Reader> GetAll()
        {
            return readers;
        }
    }
}
