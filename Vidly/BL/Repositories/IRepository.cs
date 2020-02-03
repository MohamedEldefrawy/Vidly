using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.BL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string children);
        List<TEntity> GetAll(string children);
        void Add(TEntity entity);
        void Remove(TEntity entity);

    }
}
