using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Library.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<TEntity> entities;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            entities.Add(entity);
        }

        public virtual void Delete(TKey id)
        {
            entities.Remove(dbContext.Set<TEntity>().Find(id));
        }

        public virtual TEntity Read(TKey id)
        {
            return entities.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            entities.Update(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return entities.AsNoTracking().ToList();
        }
    }
}