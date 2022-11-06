using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Gooding.DataContract.Abstractions.BrandModule;

namespace Tesla.Gooding.DataContract.BrandModule.DTO
{
    /// <summary>
    /// 商品品牌
    /// </summary>
    public class BrandDto : IBrand
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

        /// <summary>
        /// 品牌图片
        /// </summary>
        public string BrandLogo { get; set; }
    }
}
