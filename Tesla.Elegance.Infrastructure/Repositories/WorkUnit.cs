using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tesla.Elegance.Domain.Abstractions;
using Tesla.Elegance.Infrastructure.Contexts;

namespace Tesla.Elegance.Infrastructure.Repositories
{
    public class WorkUnit : IWorkUnit, IDisposable
    {
        private readonly EleganceContext _dbContext;
        public WorkUnit(EleganceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed = false;
        ~WorkUnit()
        {
            Dispose();
        }
    }
}
