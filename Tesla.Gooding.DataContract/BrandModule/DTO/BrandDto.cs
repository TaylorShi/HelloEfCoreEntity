using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.DataContract.Abstractions.TenantModule.DTO;
using Tesla.Gooding.DataContract.Abstractions.BrandModule;
using Tesla.Gooding.DataContract.Abstractions.BrandModule.DTO;

namespace Tesla.Gooding.DataContract.BrandModule.DTO
{
    /// <summary>
    /// 商品品牌
    /// </summary>
    public class BrandDto : IBrandDto, ITenantDto
    {
        /// <summary>
        /// 商户ID
        /// </summary>
        public string TenantId { get; set; }

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
