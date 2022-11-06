using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.DataContract.Abstractions.TenantModule;
using Tesla.Gooding.DataContract.Abstractions.BrandModule;

namespace Tesla.Gooding.DataContract.BrandModule.VO
{
    /// <summary>
    /// 分页查询品牌
    /// </summary>
    public class BrandPagedQueryVo : PublicTenantPageVo, IBrandVo
    {
        /// <summary>
        /// 品牌Id
        /// </summary>
        public string BrandId { get; set; }

        /// <summary>
        /// 品牌编码
        /// </summary>
        public string BrandCode { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }
    }
}
