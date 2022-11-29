using System;
using System.Collections.Generic;
using System.Text;

namespace Tesla.Elegance.Domain.Abstractions
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
