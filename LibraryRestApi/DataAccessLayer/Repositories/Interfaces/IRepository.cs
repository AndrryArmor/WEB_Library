using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryRestApi.DataAccessLayer.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        void Create(TEntity item);
        TEntity Read(TKey id);
        void Update(TEntity item);
        void Delete(TKey id);
        IQueryable<TEntity> GetAll();
    }
}
