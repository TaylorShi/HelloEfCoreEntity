using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.DataContract.Abstractions.TenantModule.VO;
using Tesla.Gooding.DataContract.Abstractions.BrandModule.VO;

namespace Tesla.Gooding.DataContract.BrandModule.VO
{
    /// <summary>
    /// 存在品牌
    /// </summary>
    public class ExistedBrandVo : TenantVo, IBrandVo
    {
        /// <summary>
        /// 品牌Id
        /// </summary>
        public string BrandId { get; set; }
    }
}
