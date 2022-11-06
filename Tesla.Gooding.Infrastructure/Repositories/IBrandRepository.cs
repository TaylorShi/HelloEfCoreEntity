using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.Infrastructure.Core.Repositorys;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;

namespace Tesla.Gooding.Infrastructure.Repositories
{
    /// <summary>
    /// 品牌仓储接口
    /// </summary>
    public interface IBrandRepository : IRepository<Brand, Guid>
    {

    }
}
