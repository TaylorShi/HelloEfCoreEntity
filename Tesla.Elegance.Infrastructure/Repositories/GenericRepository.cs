using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tesla.Elegance.Domain.Abstractions;
using Tesla.Elegance.Infrastructure.Contexts;

namespace Tesla.Elegance.Infrastructure.Repositories
{
    public class GenericRepository<TEntity, Tkey> : IAsyncRepository<TEntity, Tkey> where TEntity : class
    {
        protected readonly EleganceContext _dbContext;

        public GenericRepository(EleganceContext dbContext)
        {
            _dbContext = dbContext;
        }

        ~GenericRepository()
        {
            _dbContext?.Dispose();
        }

        public virtual IQueryable<TEntity> All()
        {
            return All(null);
        }

        public virtual IQueryable<TEntity> All(string[] propertiesToInclude)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking();

            if (propertiesToInclude != null)
            {
                foreach (var property in propertiesToInclude.Where(p => !string.IsNullOrWhiteSpace(p)))
                {
                    query = query.Include(property);
                }
            }

            return query;
        }

        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter)
        {
            return Where(filter, null);
        }

        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter, string[] propertiesToInclude)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (propertiesToInclude != null)
            {
                foreach (var property in propertiesToInclude.Where(p => !string.IsNullOrWhiteSpace(p)))
                {
                    query = query.Include(property);
                }
            }

            return query;
        }
    }

}
