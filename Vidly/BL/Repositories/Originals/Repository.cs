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
            if (children.ToUpper() == "NO")
            {
                return this.context.Set<TEntity>().Where<TEntity>(predicate);

            }
            else
            {
                return this.context.Set<TEntity>().Include(children).Where<TEntity>(predicate);

            }
        }


        public List<TEntity> GetAll(string children)
        {
            if (children.ToUpper() == "NO")
            {
                return this.context.Set<TEntity>().ToList<TEntity>();

            }

            else
            {
                return this.context.Set<TEntity>().Include(children).ToList<TEntity>();

            }
        }

        public void Remove(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
        }

    }
}