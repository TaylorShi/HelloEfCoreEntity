using System;
using System.Collections.Generic;
using System.Text;

namespace Tesla.Gooding.DataContract.Abstractions.BrandModule
{
    /// <summary>
    /// 品牌入参接口
    /// </summary>
    public interface IBrandVo
    {
        /// <summary>
        /// 品牌Id
        /// </summary>
        string BrandId { get; set; }

        /// <summary>
        /// 品牌编码
        /// </summary>
        string BrandCode { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        string BrandName { get; set; }
    }
}
