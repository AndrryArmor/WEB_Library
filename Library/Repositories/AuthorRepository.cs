using Library.Entities;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        private DbSet<Author> _authors;

        public AuthorRepository(DbContext dbContext)
        {
            _authors = dbContext.Set<Author>();
        }

        public void Create(Author item)
        {
            _authors.Add(item);
        }

        public Author Read(int id)
        {
            return _authors.Find(id);
        }

        public void Update(Author item)
        {
            _authors.Update(item);
        }

        public void Delete(int id)
        {
            _authors.Remove(_authors.Find(id));
        }

        public IEnumerable<Author> GetAll()
        {
            return _authors;
        }
    }
}
