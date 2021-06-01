using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models.Repository
{
    public interface IRepository<TEntity, TIdentity>
    {
        IList<TEntity> ReadAll();
        TEntity ReadById(TIdentity id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
