using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Vidly.DAL;

namespace Vidly.BL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly VidlyDbContext context;

        public Repository(VidlyDbContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string children)
        {
            return this.context.Set<TEntity>().Include(children).Where<TEntity>(predicate);
        }


        public List<TEntity> GetAll(string children)
        {
            return this.context.Set<TEntity>().Include(children).ToList<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
        }

    }
}