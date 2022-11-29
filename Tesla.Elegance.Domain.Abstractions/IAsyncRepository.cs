using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace Tesla.Elegance.Domain.Abstractions
{
    public interface IAsyncRepository<TEntity, Tkey> where TEntity : class
    {
        IQueryable<TEntity> All();
        IQueryable<TEntity> All(string[] propertiesToInclude);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter, string[] propertiesToInclude);
    }

}
