using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.DataContract.Abstractions.TenantModule.VO;
using Tesla.Gooding.DataContract.Abstractions.BrandModule.VO;

namespace Tesla.Gooding.DataContract.BrandModule.VO
{
    /// <summary>
    /// 分页搜索品牌
    /// </summary>
    public class PagedBrandSearchVo : TenantPageVo, IBrandSearchVo
    {
        /// <summary>
        /// 品牌Id列表
        /// </summary>
        public List<string> BrandIdList { get; set; }

        /// <summary>
        /// 品牌名称列表
        /// </summary>
        public List<string> BrandNameList { get; set; }

        /// <summary>
        /// 品牌编码列表
        /// </summary>
        public List<string> BrandCodeList { get; set; }
    }
}
