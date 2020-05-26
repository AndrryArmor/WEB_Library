using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace Library.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly LibraryContext _libraryContext;
        protected readonly DbSet<TEntity> entities;

        public Repository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
            entities = libraryContext.Set<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            entities.Add(entity);
            _libraryContext.SaveChanges();
        }

        public virtual void Delete(TKey id)
        {
            entities.Remove(entities.Find(id));
        }

        public virtual TEntity Read(TKey id)
        {
            return entities.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            entities.Update(entity);
            _libraryContext.SaveChanges();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return entities.AsQueryable();
        }
    }
}