using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.Infrastructure.Core.Repositorys;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;
using Tesla.Gooding.Infrastructure.Contexts;

namespace Tesla.Gooding.Infrastructure.Repositories
{
    /// <summary>
    /// 品牌仓储
    /// </summary>
    public class BrandRepository : Repository<Brand, Guid, GoodingMasterContext>, IBrandRepository
    {
        public BrandRepository(GoodingMasterContext context) : base(context)
        {
        }
    }
}
