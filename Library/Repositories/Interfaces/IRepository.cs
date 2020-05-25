using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        void Create(TEntity item);
        TEntity Read(TKey id);
        void Update(TEntity item);
        void Delete(TKey id);
        IEnumerable<TEntity> GetAll();
    }
}
