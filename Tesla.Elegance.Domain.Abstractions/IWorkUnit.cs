using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.Elegance.Domain.Abstractions
{
    public interface IWorkUnit
    {
        Task SaveAsync();
    }
}
